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
import { ApplicationModelsApiModelsApiBaseEntity } from './applicationModelsApiModelsApiBaseEntity';
import { ApplicationModelsApiModelsApiModificationHistory } from './applicationModelsApiModelsApiModificationHistory';
import { ApplicationModelsApiModelsApiPerson } from './applicationModelsApiModelsApiPerson';
import { DomainDataTypesFormattedContent } from './domainDataTypesFormattedContent';

export interface ApplicationModelsApiModelsApiMaterialSpecification extends ApplicationModelsApiModelsApiBaseEntity { 
    name?: string;
    title?: DomainDataTypesFormattedContent;
    description?: DomainDataTypesFormattedContent;
}