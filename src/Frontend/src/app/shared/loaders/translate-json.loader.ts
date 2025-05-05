import { TranslateLoader } from '@ngx-translate/core';
import { of } from 'rxjs';

import * as translationDe from '../i18n/de.json';
import * as translationIt from '../i18n/it.json';

export class TranslateJsonLoader implements TranslateLoader {

    public getTranslation(lang: string) {
        switch (lang) {
            case 'it':
                return of(translationIt);
            default: 
                return of(translationDe);
        }
    }
}