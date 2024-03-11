import { Injectable } from '@angular/core';

@Injectable({
    providedIn: "root"
})
export class LocalStorageService {

    set(key: string, value: string){
        if(typeof localStorage === 'undefined')
            return;
        localStorage?.setItem(key, value);
    }

    get(key: string) {
        if(typeof localStorage === 'undefined')
            return;
        return localStorage?.getItem(key);
    }

    remove(key: string) {
        if(typeof localStorage === 'undefined')
            return;
        localStorage?.removeItem(key);
    }
}