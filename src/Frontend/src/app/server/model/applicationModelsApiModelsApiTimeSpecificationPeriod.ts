/**
 * WebApi
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { ApplicationModelsApiModelsApiTimeSpecification } from './applicationModelsApiModelsApiTimeSpecification';
import { ApplicationModelsApiModelsApiTimeSpecificationMoment } from './applicationModelsApiModelsApiTimeSpecificationMoment';

export interface ApplicationModelsApiModelsApiTimeSpecificationPeriod extends ApplicationModelsApiModelsApiTimeSpecification { 
    start?: ApplicationModelsApiModelsApiTimeSpecificationMoment;
    end?: ApplicationModelsApiModelsApiTimeSpecificationMoment;
}