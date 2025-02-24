export function parseMoneyWithFallback(value: any, fallback: number | null): number | null{
    //todo
    return parseFloatWithFallback(value?.replace("€", "").trim() ?? "", fallback);
}

export function parseFloatWithFallback(value: any, fallback: number | null): number | null{
    const f = parseFloat(value?.replace(",", "."));
    if(isNaN(f)){
        return fallback;
    }
    return f;
}

export function getShortYear(year: number): number{
    return year - 2000;
}