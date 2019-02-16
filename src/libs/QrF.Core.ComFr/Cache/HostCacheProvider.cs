﻿using CacheManager.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace QrF.Core.ComFr.Cache
{
    public class HostCacheProvider : ICacheProvider
    {
        private readonly ConcurrentDictionary<string, object> _allCacheManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HostCacheProvider(IHttpContextAccessor httpContextAccessor)
        {
            _allCacheManager = new ConcurrentDictionary<string, object>();
            _httpContextAccessor = httpContextAccessor;
        }
        public ICacheManager<T> Build<T>()
        {
            return (ICacheManager<T>)_allCacheManager.GetOrAdd(Key(typeof(T).FullName), k =>
            {
                return new DefaultCacheManager<T>(CacheFactory.Build<T>(setting =>
                {
                    setting.WithDictionaryHandle(k);
                }));
            });
        }
        public string Key(string key)
        {
            string host = _httpContextAccessor.HttpContext.Request.Host.Value.ToLowerInvariant();
            if (host.StartsWith("www."))
            {
                return $"{host.Substring(4)}-{key}";
            }
            return $"{host}-{key}";
        }
    }
}