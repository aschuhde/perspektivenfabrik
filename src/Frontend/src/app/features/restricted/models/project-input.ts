import { ApplicationModelsApiModelsApiContactSpecification } from "../../../server/model/applicationModelsApiModelsApiContactSpecification";
import { ApplicationModelsApiModelsApiContactSpecificationMailAddress } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationMailAddress";
import { ApplicationModelsApiModelsApiContactSpecificationPhoneNumber } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPhoneNumber";
import { ApplicationModelsApiModelsApiContactSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationTypes";
import { ApplicationModelsApiModelsApiDescriptionSpecification } from "../../../server/model/applicationModelsApiModelsApiDescriptionSpecification";
import { ApplicationModelsApiModelsApiGraphicsSpecification } from "../../../server/model/applicationModelsApiModelsApiGraphicsSpecification";
import { ApplicationModelsApiModelsApiProjectBody } from "../../../server/model/applicationModelsApiModelsApiProjectBody";
import { ApplicationModelsApiModelsApiRequirementSpecification } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecification";
import { DomainEnumsProjectPhase } from "../../../server/model/domainEnumsProjectPhase";
import { DomainEnumsProjectType } from "../../../server/model/domainEnumsProjectType";
import { DomainEnumsProjectVisibility } from "../../../server/model/domainEnumsProjectVisibility";
import { UploadedImage } from "../../../shared/models/uploaded-image";
import { ObjectCreator } from "../../../shared/tools/object-creator";
import { LocationInput } from "./location-input";
import { ProjectTimeInput } from "./project-time-input";
import { RequirementMaterialInput } from "./requirement-material-input";
import { RequirementMoneyInput } from "./requirement-money-input";
import { RequirementPersonInput } from "./requirement-person-input";

export declare type ProjectType = "project" | "idea" | "inspiration" | "none";

export class ProjectInput{
    projectType: ProjectType = "none";
    projectTitle: string = ""
    projectPhase: "unknown" | "planning" | "ongoing" | "finished" | "cancelled" = "unknown";
    locations: LocationInput[] = [new LocationInput()];
    projectTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
    requirementPersons: RequirementPersonInput[] = [new RequirementPersonInput()];
    requirementMaterials: RequirementMaterialInput[] = [new RequirementMaterialInput()];
    requirementsMoney: RequirementMoneyInput[] = [new RequirementMoneyInput()];
    contactMail: string = ""
    contactPhone: string = ""
    description: string = ""
    uploadedImages: UploadedImage[] = []
    projectVisibility: "draft" | "public" | "internal" = "draft"
    get projectName(){
        return this.projectTitle; //todo: generate name
    }
    get typeName(){
        switch(this.projectType){
          case "project":
          case "none":
            return "Projekt";
          case "idea":
            return "Idee";
          case "inspiration":
            return "Inspiration";
        }
      }
      get yourDeclination(){
        switch(this.projectType){
          case "project":
          case "none":
            return "dein";
          case "idea":
            return "deine";
          case "inspiration":
            return "deine";
        }
      }
      get yoursDeclination(){
        switch(this.projectType){
          case "project":
          case "none":
            return "deines";
          case "idea":
            return "deiner";
          case "inspiration":
            return "deiner";
        }
      }
    buildRequest(): ApplicationModelsApiModelsApiProjectBody{
        return {
          projectTitle: {
            rawContentString: this.projectTitle
          },
          connectedOrganizations: [],
          connectedOrganizationsSameAsOwner: false,
          contactSpecifications: this.getContactSpecifications(),
          contributors: [],
          descriptionSpecifications: [ObjectCreator.Create<ApplicationModelsApiModelsApiDescriptionSpecification>({
            type: {
              name: "", //todo
              descriptionTitle: {
                rawContentString: "", //todo
              }
            },
            content: {
              rawContentString: this.description
            }
          })],
          graphicsSpecifications: this.uploadedImages.map(x => {
            return ObjectCreator.Create<ApplicationModelsApiModelsApiGraphicsSpecification>({
              type: x.getType(),
              content: {
                content: "todo"
              }
            }); 
          }),
          locationSpecifications: this.locations.map(x => x.toLocationSpecification()).filter(x => !!x),
          phase: this.getProjectPhaseForApi(),
          projectName: this.projectName,
          projectTags: [],
          relatedProjects: [],
          timeSpecifications: this.projectTimes.map(x => x.toTimeSpecification()).filter(x => !!x),
          requirementSpecifications: this.getRequirementSpecifications(),
          visibility: this.getProjectVisibilityForApi(),
          type: this.getProjectTypeForApi()
        };
      }
    
      getRequirementSpecifications(): ApplicationModelsApiModelsApiRequirementSpecification[]{
        const result: ApplicationModelsApiModelsApiRequirementSpecification[] = [];
        result.push(...this.requirementMaterials.flatMap(x => x.toRequirementMaterialSpecifications()));
        result.push(...this.requirementPersons.map(x => x.toRequirementPersonSpecification()));
        result.push(...this.requirementsMoney.map(x => x.toRequirementMoneySpecification()));
        return result;
      }
      getProjectTypeForApi(): DomainEnumsProjectType{
        switch(this.projectType){
          case "idea":
            return "Idea";
          case "inspiration":
            return "Inspiration";
          case "project":
            return "Project";
        }
        return "Unkown";
      }
      getProjectVisibilityForApi(): DomainEnumsProjectVisibility{
        switch(this.projectVisibility){
          case "draft":
            return "Draft";
          case "internal":
            return "Internal";
          case "public":
            return "Public";
        }
        return "Unkown";
      }
      getProjectPhaseForApi(): DomainEnumsProjectPhase{
        switch(this.projectPhase){
          case 'cancelled':
            return "Cancelled";
          case 'ongoing':
            return "Ongoing";
          case 'finished':
            return "Finished";
          case 'planning':
            return "Planning";
        }
        return "Unkown"
      }
    
      getContactSpecifications(){
        const contactSpecifications: ApplicationModelsApiModelsApiContactSpecification[] = []
        if(this.contactPhone){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPhoneNumber>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.PhoneNumber,
            phoneNumber: {
              phoneNumberText: this.contactPhone
            }
          }));
        }
        if(this.contactMail){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationMailAddress>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.MailAddress,
            mailAddress: {
              mail: this.contactMail
            }
          }));
        }
        return contactSpecifications;
      }
}