import {HttpClient} from '@angular/common/http';
import { Language } from '../../core/types/general-types';

export function getNominatimOsmEntry(language: Language, osmId: string, osmType: string, placeId: string, httpClient: HttpClient) {
    let typePrefix = osmType === 'node' ? 'N' : osmType === "way" ? 'W' : osmType === "relation" ? 'R' : 'N';
    let params: any = {
        'osm_ids': typePrefix + osmId,
        'accept-language': language,
        'format': 'json',
        "addressdetails": 1
    };
    if(osmType){
        params['osmtype'] = osmType;
    }
    if(placeId){
        params['place_id'] = placeId;
    }
    return httpClient.get(`https://nominatim.openstreetmap.org/lookup`, {
        params: params
    }).toPromise();
}