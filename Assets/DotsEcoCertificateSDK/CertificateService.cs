﻿using UnityEngine.Networking;
using System;

namespace DotsEcoCertificateSDK
{
    public class CertificateService
    {
        private string authToken;

        public CertificateService(string authToken)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentException("authToken is required!", nameof(authToken));
            }
            this.authToken = authToken;
        }

        public UnityWebRequest GetCertificateRequest(string appToken, string certificateId)
        {
            GetCertificateRequestBuilder builder = new GetCertificateRequestBuilder(appToken, certificateId);
            return PrepareRequest(builder);
        }

        public UnityWebRequest GetCertificateRequest(GetCertificateRequestBuilder builder)
        {
            return PrepareRequest(builder);
        }

        public UnityWebRequest CreateCertificateRequest(string appToken, int allocationId, int impactQty, string remoteUserId)
        {
            CreateCertificateRequestBuilder builder = new CreateCertificateRequestBuilder(appToken, allocationId, impactQty, remoteUserId);
            return PrepareRequest(builder);
        }

        public UnityWebRequest CreateCertificateRequest(CreateCertificateRequestBuilder builder)
        {
            return PrepareRequest(builder);
        }

        public UnityWebRequest ImpactSummaryByUserId(string companyId, string appToken, string remoteUserId)
        {
            ImpactSummaryRequestBuilder builder = new ImpactSummaryRequestBuilder(authToken, companyId, appToken, remoteUserId);
            return PrepareRequest(builder);
        }

        public UnityWebRequest ImpactSummaryByUserId(ImpactSummaryRequestBuilder builder)
        {
            return PrepareRequest(builder);
        }

        private UnityWebRequest PrepareRequest(IRequestBuilder builder)
        {
            UnityWebRequest request = builder.BuildRequest();
            request.SetRequestHeader("auth-token", authToken);
            return request;
        }

        public object GetCertificateRequest(object testAppToken, string testCertificateId)
        {
            throw new NotImplementedException();
        }
    }
}