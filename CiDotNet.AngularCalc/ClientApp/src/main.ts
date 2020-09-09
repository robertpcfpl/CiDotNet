import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { isDevMode } from '@angular/core';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

const api_prod_url= 'http://localhost:4250/'
export function getBaseUrl() {
  if(isDevMode()) {
    return document.getElementsByTagName('base')[0].href;
  }
  else {
    return api_prod_url;
  };
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
