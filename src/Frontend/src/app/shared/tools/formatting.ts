import {formatNumber} from "@angular/common";
import { parseMoneyWithFallback } from "./parsing";

export function formatMoney(value: unknown, locale: string, currency: "euro"){
    const number = typeof value === "number" ? value : parseMoneyWithFallback(value, null);
    if(typeof number !== "number"){
        return "";
    }
    //todo
    return `${formatNumber(number, "en-en", "1.2-2")} €`;
}