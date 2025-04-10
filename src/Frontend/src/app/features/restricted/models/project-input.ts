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
import {GalleryImage} from "../../../shared/models/gallery-image";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationTypes
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {ApplicationModelsApiModelsApiProjectTag} from "../../../server/model/applicationModelsApiModelsApiProjectTag";

export declare type ProjectType = "project" | "idea" | "inspiration" | "none";

export class ProjectInput{
    entityId: string | null = null;
    shortDescriptionEntityId: string | null = null;
    shortDescriptionTypeEntityId: string | null = null;
    longDescriptionEntityId: string | null = null;
    longDescriptionTypeEntityId: string | null = null;
    projectType: ProjectType = "none";
    projectTitle: string = ""
    projectPhase: "unknown" | "planning" | "ongoing" | "finished" | "cancelled" = "planning";
    locations: LocationInput[] = [];
    projectTimes: ProjectTimeInput[] = [];
    requirementPersons: RequirementPersonInput[] = [];
    requirementMaterials: RequirementMaterialInput[] = [];
    requirementsMoney: RequirementMoneyInput[] = [];
    selectedTags: SelectOption[] = []
    contactMail: string = ""
    contactMailEntityId : string | null = null;
    contactPhone: string = ""
    contactPhoneEntityId : string | null = null;
    organisationName: string = ""
    contactOrganisationNameEntityId : string | null = null;
    contactName: string = ""
    contactNameEntityId : string | null = null;
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
      
    loadFromProject(project: ApplicationModelsApiModelsApiProjectBody){
      if (!project) {
        return;
      }
      this.entityId = project.entityId ?? null;
      

      this.loadProjectTypeFromApi(project.type ?? "Unkown");

      this.projectTitle = project.projectTitle?.rawContentString ?? "";
      this.loadProjectPhaseFromApi(project.phase ?? "Unkown");

      this.locations = (project.locationSpecifications ?? []).map(
        (location) => LocationInput.fromLocationSpecification(location)
      ).filter(x => !!x);
      this.projectTimes = (project.timeSpecifications ?? []).map(
        (time) => ProjectTimeInput.fromTimeSpecification(time)
      ).filter(x => !!x);
      this.requirementPersons = (project.requirementSpecifications ?? []).filter(x => x.classType == ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person).map(
        (req) => RequirementPersonInput.fromRequirementSpecification(req as ApplicationModelsApiModelsApiRequirementSpecificationPerson)
      );
      this.requirementMaterials = (project.requirementSpecifications ?? []).filter(x => x.classType == ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material).flatMap(
        (req) => RequirementMaterialInput.fromRequirementSpecification(req)
      );
      this.requirementsMoney = (project.requirementSpecifications ?? []).filter(x => x.classType == ApplicationModelsApiModelsApiRequirementSpecificationTypes.Money).flatMap(
        (req) => RequirementMoneyInput.fromRequirementSpecification(req)
      );
      this.selectedTags = (project.projectTags ?? []).map(x => {
        return new SelectOption(x.tagName ?? x.entityId ?? "", x.tagName, x.entityId ?? null);
      }).filter(x => !!x.value);

      this.loadContactSpecificationsFromApi(project.contactSpecifications ?? []);
      const shortDescriptionObj = project.descriptionSpecifications?.find(
          (desc) => desc.type?.name === "shortDescription"
      );
        const longDescriptionObj = project.descriptionSpecifications?.find(
            (desc) => desc.type?.name === "longDescription"
        );
        this.shortDescription =
          shortDescriptionObj?.content?.rawContentString ?? "";
        this.shortDescriptionEntityId = shortDescriptionObj?.entityId ?? null; 
        this.shortDescriptionTypeEntityId = shortDescriptionObj?.type?.entityId ?? null; 
            this.longDescription =
        longDescriptionObj?.content?.rawContentString ?? "";
        this.longDescriptionEntityId = longDescriptionObj?.entityId ?? null;
        this.longDescriptionTypeEntityId = longDescriptionObj?.type?.entityId ?? null;
      this.uploadedImages = project?.graphicsSpecifications?.map(x => UploadedImage.fromApi(x)) ?? [];
      this.loadProjectVisibilityFromApi(project.visibility ?? "Unkown");
    }  
    async buildRequest(): Promise<ApplicationModelsApiModelsApiProjectBody>{      
      const graphicsSpecifications: ApplicationModelsApiModelsApiGraphicsSpecification[] = [];
      for(const uploadedImage of this.uploadedImages){
        graphicsSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiGraphicsSpecification>({
          type: uploadedImage.getType(),
            entityId: uploadedImage.entityId ?? undefined,
          content: {
            content: await uploadedImage.getBase64()
          }
        }));
      }
        return {
          entityId: this.entityId ?? undefined,
          projectTitle: {
            rawContentString: this.projectTitle
          },
          connectedOrganizations: [],
          connectedOrganizationsSameAsOwner: false,
          contactSpecifications: this.getContactSpecifications(),
          contributors: [],
          descriptionSpecifications: [ObjectCreator.Create<ApplicationModelsApiModelsApiDescriptionSpecification>({
              entityId: this.shortDescriptionEntityId ?? undefined,
            type: {
              name: "shortDescription",
                entityId: this.shortDescriptionTypeEntityId ?? undefined,
              descriptionTitle: {
                rawContentString: "Kurzbeschreibung",
              }
            },
            content: {
              rawContentString: this.shortDescription
            }
          }),
          ObjectCreator.Create<ApplicationModelsApiModelsApiDescriptionSpecification>({
              entityId: this.longDescriptionEntityId ?? undefined,
            type: {
              name: "longDescription",
                entityId: this.longDescriptionTypeEntityId ?? undefined,
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
          projectTags: this.selectedTags.map(x => ObjectCreator.Create<ApplicationModelsApiModelsApiProjectTag>({
              tagName: x?.text ?? x?.value ?? "",
              entityId: x?.entityId ?? undefined
          })).filter(x => !!x),
          relatedProjects: [],
          timeSpecifications: this.projectTimes.map(x => x.toTimeSpecification()).filter(x => !!x),
          requirementSpecifications: this.getRequirementSpecifications(),
          visibility: this.getProjectVisibilityForApi(),
          type: this.getProjectTypeForApi()
        };
      }
    
      getRequirementSpecifications(): ApplicationModelsApiModelsApiRequirementSpecification[]{
        const result: ApplicationModelsApiModelsApiRequirementSpecification[] = [];
        result.push(...this.requirementMaterials.map(x => x.toRequirementMaterialSpecifications()));
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

  loadProjectTypeFromApi(projectType: DomainEnumsProjectType) {
    if (projectType === "Project") {
      this.projectType = "project";
    } else if (projectType === "Idea") {
      this.projectType = "idea";
    } else if (projectType === "Inspiration") {
      this.projectType = "inspiration";
    } else {
      this.projectType = "none";
    }
  }

  loadProjectPhaseFromApi(projectPhase: DomainEnumsProjectPhase) {
    if (projectPhase === "Planning") {
      this.projectPhase = "planning";
    } else if (projectPhase === "Ongoing") {
      this.projectPhase = "ongoing";
    } else if (projectPhase === "Finished") {
      this.projectPhase = "finished";
    } else if (projectPhase === "Cancelled") {
      this.projectPhase = "cancelled";
    } else {
      this.projectPhase = "unknown";
    }
  }

  loadProjectVisibilityFromApi(projectVisibility: DomainEnumsProjectVisibility) {
    if (projectVisibility === "Draft") {
      this.projectVisibility = "draft";
    } else if (projectVisibility === "Internal") {
      this.projectVisibility = "internal";
    } else if (projectVisibility === "Public") {
      this.projectVisibility = "public";
    } else {
      this.projectVisibility = "draft";
    }
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
    
      loadContactSpecificationsFromApi(contactSpecifications: ApplicationModelsApiModelsApiContactSpecification[]){
        const contactNameObj = contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PersonalName) as ApplicationModelsApiModelsApiContactSpecificationPersonalName;
        this.contactName = contactNameObj?.personalName ?? "";
        this.contactNameEntityId = contactNameObj?.entityId ?? null;
        const organisationNameObj = contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.OrganisationName) as ApplicationModelsApiModelsApiContactSpecificationOrganisationName;
        this.organisationName = organisationNameObj?.organisationName ?? "";
        this.contactOrganisationNameEntityId = organisationNameObj?.entityId ?? null;
        const contactPhoneObj = contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PhoneNumber) as ApplicationModelsApiModelsApiContactSpecificationPhoneNumber;
        this.contactPhone = contactPhoneObj?.phoneNumber?.phoneNumberText ?? "";
        this.contactPhoneEntityId = contactPhoneObj?.entityId ?? null;
        const contactMailObj = contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.MailAddress) as ApplicationModelsApiModelsApiContactSpecificationMailAddress;
        this.contactMail = contactMailObj?.mailAddress?.mail ?? "";
        this.contactMailEntityId = contactMailObj?.entityId ?? null;
        
        this.contactSpecifications = contactSpecifications.map(x => {
          if(x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.Paypal){
            return ContactSpecification.fromContactSpecificationPaypal(x as ApplicationModelsApiModelsApiContactSpecificationPaypal);
          }
          
          if(x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.BankAccount){
            return ContactSpecification.fromContactSpecificationBankAccount(x as ApplicationModelsApiModelsApiContactSpecificationBankAccount);
          }
          
          if(x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.Website){
            return ContactSpecification.fromContactSpecificationWebsite(x as ApplicationModelsApiModelsApiContactSpecificationWebsite);
          }
          return null;
        }).filter(x => !!x);
      }
      
      getContactSpecifications(){
        const contactSpecifications: ApplicationModelsApiModelsApiContactSpecification[] = []
        if(this.contactPhone){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPhoneNumber>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.PhoneNumber,
              entityId: this.contactPhoneEntityId ?? undefined,
            phoneNumber: {
              phoneNumberText: this.contactPhone
            }
          }));
        }
        if(this.contactMail){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationMailAddress>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.MailAddress,
              entityId: this.contactMailEntityId ?? undefined,
            mailAddress: {
              mail: this.contactMail
            }
          }));
        }
        if(this.contactName){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPersonalName>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.PersonalName,
              entityId: this.contactNameEntityId ?? undefined,
            personalName: this.contactName
          }))
        }
        if(this.organisationName){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationOrganisationName>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.OrganisationName,
              entityId: this.contactOrganisationNameEntityId ?? undefined,
            organisationName: this.organisationName
          }))
        }

        for(const contactSpecification of this.contactSpecifications){
          if(contactSpecification.contactSpecificationType === "bankAccount"){
            contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationBankAccount>({
              classType: ApplicationModelsApiModelsApiContactSpecificationTypes.BankAccount,
                entityId: contactSpecification.entityId ?? undefined,
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
                entityId: contactSpecification.entityId ?? undefined,
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
                entityId: contactSpecification.entityId ?? undefined,
              website: {
                rawUrl: contactSpecification.website
              }
            }))
          }
        }
        return contactSpecifications;
      }
}