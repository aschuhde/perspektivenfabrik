import { DateTime } from "luxon";

export class DateTools{
    static ToDateOnlyApiString(date: DateTime | null){
        return date?.toFormat("yyyy-MM-dd") ?? null;
    }
    static ToDateOnlyApiStringNotNull(date: DateTime){
        return date.toFormat("yyyy-MM-dd");
    }
}