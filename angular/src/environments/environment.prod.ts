import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'PayPalIntegrtion',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44366/',
    redirectUri: baseUrl,
    clientId: 'PayPalIntegrtion_App',
    responseType: 'code',
    scope: 'offline_access PayPalIntegrtion',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44366',
      rootNamespace: 'PayPalIntegrtion',
    },
  },
} as Environment;
