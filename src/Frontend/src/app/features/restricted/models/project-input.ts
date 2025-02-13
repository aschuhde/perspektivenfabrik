import { ApplicationModelsApiModelsApiContactSpecification } from "../../../server/model/applicationModelsApiModelsApiContactSpecification";
import { ApplicationModelsApiModelsApiContactSpecificationBankAccount } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationBankAccount";
import { ApplicationModelsApiModelsApiContactSpecificationMailAddress } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationMailAddress";
import { ApplicationModelsApiModelsApiContactSpecificationOrganisationName } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationOrganisationName";
import { ApplicationModelsApiModelsApiContactSpecificationPaypal } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPaypal";
import { ApplicationModelsApiModelsApiContactSpecificationPersonalName } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPersonalName";
import { ApplicationModelsApiModelsApiContactSpecificationPhoneNumber } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPhoneNumber";
import { ApplicationModelsApiModelsApiContactSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationTypes";
import { ApplicationModelsApiModelsApiContactSpecificationWebsite } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationWebsite";
import { ApplicationModelsApiModelsApiDescriptionSpecification } from "../../../server/model/applicationModelsApiModelsApiDescriptionSpecification";
import { ApplicationModelsApiModelsApiGraphicsSpecification } from "../../../server/model/applicationModelsApiModelsApiGraphicsSpecification";
import { ApplicationModelsApiModelsApiProjectBody } from "../../../server/model/applicationModelsApiModelsApiProjectBody";
import { ApplicationModelsApiModelsApiRequirementSpecification } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecification";
import { DomainEnumsProjectPhase } from "../../../server/model/domainEnumsProjectPhase";
import { DomainEnumsProjectType } from "../../../server/model/domainEnumsProjectType";
import { DomainEnumsProjectVisibility } from "../../../server/model/domainEnumsProjectVisibility";
import { SelectOption } from "../../../shared/models/select-option";
import { UploadedImage } from "../../../shared/models/uploaded-image";
import { ObjectCreator } from "../../../shared/tools/object-creator";
import { ContactSpecification } from "./contact-specification";
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
    selectedTags: SelectOption[] = []
    contactMail: string = ""
    contactPhone: string = ""
    organisationName: string = ""
    contactName: string = ""
    contactSpecifications: ContactSpecification[] = []
    shortDescription: string = ""
    longDescription: string = ""
    uploadedImages: UploadedImage[] = []
    projectVisibility: "draft" | "public" | "internal" = "draft"
    get projectName(){
        return this.projectTitle?.replaceAll(" ", ""); //todo: generate name
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
    async buildRequest(): Promise<ApplicationModelsApiModelsApiProjectBody>{      
      const graphicsSpecifications: ApplicationModelsApiModelsApiGraphicsSpecification[] = [];
      for(const uploadedImage of this.uploadedImages){
        graphicsSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiGraphicsSpecification>({
          type: uploadedImage.getType(),
          content: {
            content: await uploadedImage.getBase64()
          }
        }));
      }
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
              name: "shortDescription",
              descriptionTitle: {
                rawContentString: "Kurzbeschreibung",
              }
            },
            content: {
              rawContentString: this.shortDescription
            }
          }),
          ObjectCreator.Create<ApplicationModelsApiModelsApiDescriptionSpecification>({
            type: {
              name: "longDescription",
              descriptionTitle: {
                rawContentString: "Ausführliche Beschreibung"
              }
            },
            content: {
              rawContentString: this.longDescription
            }
          })],
          graphicsSpecifications: graphicsSpecifications,
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
        if(this.contactName){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPersonalName>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.PersonalName,
            personalName: this.contactName
          }))
        }
        if(this.organisationName){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationOrganisationName>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.OrganisationName,
            organisationName: this.organisationName
          }))
        }

        for(const contactSpecification of this.contactSpecifications){
          if(contactSpecification.contactSpecificationType === "bankAccount"){
            contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationBankAccount>({
              classType: ApplicationModelsApiModelsApiContactSpecificationTypes.BankAccount,
              bankAccount: {
                accountName: contactSpecification.bankAccountName,
                bic: {
                  bicName: contactSpecification.bankAccountBic
                },
                iban: {
                  ibanName: contactSpecification.bankAccountIban
                },
                reference: contactSpecification.bankAccountReference
              }
            }))
          }
          if(contactSpecification.contactSpecificationType === "paypalAccount"){
            contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPaypal>({
              classType: ApplicationModelsApiModelsApiContactSpecificationTypes.Paypal,
              paypalAddress: {
                mail: contactSpecification.paypalAddress
              },
              paypalMeAddress: {
                rawUrl: contactSpecification.paypalMeAddress
              }
            }))
          }
          if(contactSpecification.contactSpecificationType === "website"){
            contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationWebsite>({
              classType: ApplicationModelsApiModelsApiContactSpecificationTypes.Website,
              website: {
                rawUrl: contactSpecification.website
              }
            }))
          }
        }
        return contactSpecifications;
      }
}