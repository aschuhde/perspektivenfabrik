import {formatNumber} from "@angular/common";
import { parseMoneyWithFallback } from "./parsing";
import {DomainDataTypesCoordinates} from "../../server/model/domainDataTypesCoordinates";

export function formatMoney(value: unknown, locale: string, currency: "euro"){
    const number = typeof value === "number" ? value : parseMoneyWithFallback(value, null);
    if(typeof number !== "number"){
        return "";
    }
    return `${formatNumber(number, locale, "1.2-2")} €`;
}

export function formatCoordinates(coordinates: DomainDataTypesCoordinates | null | undefined, locale: string){
    if(!coordinates || !coordinates.lat || !coordinates.lon) return "";
    return `${formatNumber(coordinates.lat, locale)}, ${formatNumber(coordinates.lon, locale)}`;
}

export function escapeHtml(html: string){
    return html
        .replaceAll("&", "&amp;")
        .replaceAll("<", "&lt;")
        .replaceAll(">", "&gt;")
        .replaceAll('"', "&quot;")
        .replaceAll("'", "&#039;");
}