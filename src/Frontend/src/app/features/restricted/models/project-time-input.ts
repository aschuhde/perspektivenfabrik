import { DateTime } from "luxon"
import { ApplicationModelsApiModelsApiTimeSpecification } from "../../../server/model/applicationModelsApiModelsApiTimeSpecification"
import { ApplicationModelsApiModelsApiTimeSpecificationMonth } from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationMonth"
import { ApplicationModelsApiModelsApiTimeSpecificationPeriod } from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationPeriod"
import { ObjectCreator } from "../../../shared/tools/object-creator"
import { ApplicationModelsApiModelsApiTimeSpecificationDate } from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationDate"
import {
  DateTools,
  getLuxonDateTimeFromMonth,
  getLuxonDateTimeFromNullableJsDate
} from "../../../shared/tools/date-tools"
import { ApplicationModelsApiModelsApiTimeSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationTypes"
import {
  ApplicationModelsApiModelsApiTimeSpecificationDateTime
} from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationDateTime";

export declare type ProjectTimeType = "unknown" | "range" | "date" | "month"
export class ProjectTimeInput{
    entityId: string | null = null;
    startEntityId: string | null = null;
    endEntityId: string | null = null;
  projectTimeType : ProjectTimeType = "range"
  startDate: DateTime | null = DateTime.now()
  endDate: DateTime | null = DateTime.now()
  month: DateTime | null = DateTime.now()
  date: DateTime | null = DateTime.now()

  toTimeSpecification(): ApplicationModelsApiModelsApiTimeSpecification | null {
    switch(this.projectTimeType){
        case "date":
            return this.date ? ObjectCreator.Create<ApplicationModelsApiModelsApiTimeSpecificationDate>({
                classType: ApplicationModelsApiModelsApiTimeSpecificationTypes.Date,
                entityId: this.entityId ?? undefined,
                date: DateTools.ToDateOnlyApiStringNotNull(this.date)
            }) : null;
        case "month":
            return this.month ? ObjectCreator.Create<ApplicationModelsApiModelsApiTimeSpecificationMonth>({
                classType: ApplicationModelsApiModelsApiTimeSpecificationTypes.Month,
                entityId: this.entityId ?? undefined,
                month: {                    
                    year: {
                        yearNumber: this.month.year
                    },
                    monthFromOneToTwelve: this.month.month
                }
            }) : null;
        case "range":
            return this.startDate && this.endDate ? ObjectCreator.Create<ApplicationModelsApiModelsApiTimeSpecificationPeriod>({
                classType: ApplicationModelsApiModelsApiTimeSpecificationTypes.Period,
                entityId: this.entityId ?? undefined,
                start: ObjectCreator.Create<ApplicationModelsApiModelsApiTimeSpecificationDate>({
                    classType: ApplicationModelsApiModelsApiTimeSpecificationTypes.Date,
                    entityId: this.startEntityId ?? undefined,
                    date: DateTools.ToDateOnlyApiStringNotNull(this.startDate)
                }),
                end: ObjectCreator.Create<ApplicationModelsApiModelsApiTimeSpecificationDate>({
                    classType: ApplicationModelsApiModelsApiTimeSpecificationTypes.Date,
                    entityId: this.endEntityId ?? undefined,
                    date: DateTools.ToDateOnlyApiStringNotNull(this.endDate)
                }),
            }) : null;        
    }
    return null;
  }
  
  getRelevantMomentDate(){
    switch(this.projectTimeType){
        case "date":
            return this.date;
        case "month":
            return this.month;
    }
    return null;
  }

  static fromTimeSpecification(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification | null) {
    const result = new ProjectTimeInput();
    if(!timeSpecification){
      return null;
    }
      result.entityId = timeSpecification.entityId ?? null;
    if(timeSpecification.classType === ApplicationModelsApiModelsApiTimeSpecificationTypes.Date){
      result.projectTimeType = "date";
      result.date = DateTime.fromISO((timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationDate)?.date ?? "");
    }
    else if(timeSpecification.classType === ApplicationModelsApiModelsApiTimeSpecificationTypes.DateTime){
      result.projectTimeType = "date";
      result.date = getLuxonDateTimeFromNullableJsDate((timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationDateTime)?.date ?? null);
    }
    else if(timeSpecification.classType === ApplicationModelsApiModelsApiTimeSpecificationTypes.Period){
      result.projectTimeType = "range";
      result.startEntityId = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationPeriod)?.start?.entityId ?? null;
      result.endEntityId = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationPeriod)?.end?.entityId ?? null;
      result.startDate = (this.fromTimeSpecification((timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationPeriod)?.start ?? null))?.getRelevantMomentDate() ?? null;
      result.endDate = (this.fromTimeSpecification((timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationPeriod)?.end ?? null))?.getRelevantMomentDate() ?? null;       
    }
    else if(timeSpecification.classType === ApplicationModelsApiModelsApiTimeSpecificationTypes.Month){
      result.projectTimeType = "month";
      result.month = getLuxonDateTimeFromMonth((timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationMonth)?.month ?? null);
    }
    return result;
  }
}