import { DateTime } from "luxon"
import { ApplicationModelsApiModelsApiTimeSpecification } from "../../../server/model/applicationModelsApiModelsApiTimeSpecification"
import { ApplicationModelsApiModelsApiTimeSpecificationMonth } from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationMonth"
import { ApplicationModelsApiModelsApiTimeSpecificationPeriod } from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationPeriod"
import { ObjectCreator } from "../../../shared/tools/object-creator"
import { ApplicationModelsApiModelsApiTimeSpecificationDate } from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationDate"
import { DateTools } from "../../../shared/tools/date-tools"
import { ApplicationModelsApiModelsApiTimeSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationTypes"

export declare type ProjectTimeType = "unknown" | "range" | "date" | "month"
export class ProjectTimeInput{
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
                date: DateTools.ToDateOnlyApiStringNotNull(this.date)
            }) : null;
        case "month":
            return this.month ? ObjectCreator.Create<ApplicationModelsApiModelsApiTimeSpecificationMonth>({
                classType: ApplicationModelsApiModelsApiTimeSpecificationTypes.Month,
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
                start: ObjectCreator.Create<ApplicationModelsApiModelsApiTimeSpecificationDate>({
                    classType: ApplicationModelsApiModelsApiTimeSpecificationTypes.Date,
                    date: DateTools.ToDateOnlyApiStringNotNull(this.startDate)
                }),
                end: ObjectCreator.Create<ApplicationModelsApiModelsApiTimeSpecificationDate>({
                    classType: ApplicationModelsApiModelsApiTimeSpecificationTypes.Date,
                    date: DateTools.ToDateOnlyApiStringNotNull(this.endDate)
                }),
            }) : null;        
    }
    return null;
  }
    
}