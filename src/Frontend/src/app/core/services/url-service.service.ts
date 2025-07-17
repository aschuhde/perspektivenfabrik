import { inject, Injectable } from "@angular/core";
import {ActivatedRoute, Router } from "@angular/router";

@Injectable({
    providedIn: "root"
})
export class UrlService {
    router = inject(Router)
    activatedRoute = inject(ActivatedRoute)
    
    getQuery(){
        const parts = this.router.url.split('?');
        if(parts.length > 1){
            return parts[1];
        }
        return "";
    }

    getQueryParameter(queryParameterName: string){
        return this.activatedRoute.snapshot.queryParams[queryParameterName]?.toString() ?? "";
    }
}