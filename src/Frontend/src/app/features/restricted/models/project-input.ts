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
import { TranslationValue } from "../../../shared/models/translation-value";
import { Language } from "../../../core/types/general-types";

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
    contactMailTranslations: TranslationValue[] = [];
    contactMailEntityId : string | null = null;
    contactPhone: string = ""
    contactPhoneTranslations: TranslationValue[] = [];
    contactPhoneEntityId : string | null = null;
    organisationName: string = ""
    organisationNameTranslations: TranslationValue[] = [];
    contactOrganisationNameEntityId : string | null = null;
    contactName: string = ""
    contactNameTranslations: TranslationValue[] = [];
    contactNameEntityId : string | null = null;
    contactSpecifications: ContactSpecification[] = []
    shortDescription: string = ""
    shortDescriptionTranslations: TranslationValue[] = [];
    longDescription: string = ""
    longDescriptionTranslations: TranslationValue[] = [];
    uploadedImages: UploadedImage[] = []
    projectVisibility: "draft" | "public" | "internal" = "draft"
    projectTitleTranslations: TranslationValue[] = [];
    onGetCurrentLanguage: () => Language;
    
    constructor(onGetCurrentLanguage: () => Language) {
      this.onGetCurrentLanguage = onGetCurrentLanguage;
    }
    get projectName(){
        const titleMainLanguage = (this.projectTitleTranslations.find(x => x.language === this.onGetCurrentLanguage())?.value ?? this.projectTitle);
        return this.buildProjectName(titleMainLanguage);
    }

  get projectNameTranslations(){
    return this.projectTitleTranslations.map(x => new TranslationValue(x.language, this.buildProjectName(x.value ?? "")));
  }
  
  buildProjectName(title: string){
    return title
        .replace(/ä/g, 'ae')
        .replace(/ö/g, 'oe')
        .replace(/ü/g, 'ue')
        .replace(/Ä/g, 'Ae')
        .replace(/Ö/g, 'Oe')
        .replace(/Ü/g, 'Ue')
        .replace(/ß/g, 'ss')
        .replace(/è/g, 'e')
        .replace(/à/g, 'a')
        .replace(/È/g, 'e')
        .replace(/À/g, 'a')
        .replace(/[^a-zA-Z]/g, '')
        .substring(0, 50);
  }
    
    loadFromProject(project: ApplicationModelsApiModelsApiProjectBody, mainLanguage: Language, apiBasePath: string){
      if (!project) {
        return;
      }
      this.entityId = project.entityId ?? null;
      

      this.loadProjectTypeFromApi(project.type ?? "Unkown");

      
      this.projectTitleTranslations = TranslationValue.arrayFromApiTranslationValues(project.projectTitle?.contentTranslations ?? []);
      this.projectTitle = TranslationValue.getTranslationIfExist(project.projectTitle?.rawContentString ?? "", this.projectTitleTranslations, mainLanguage);
      this.loadProjectPhaseFromApi(project.phase ?? "Unkown");

      this.locations = (project.locationSpecifications ?? []).map(
        (location) => LocationInput.fromLocationSpecification(location, mainLanguage)
      ).filter(x => !!x);
      this.projectTimes = (project.timeSpecifications ?? []).map(
        (time) => ProjectTimeInput.fromTimeSpecification(time)
      ).filter(x => !!x);
      this.requirementPersons = (project.requirementSpecifications ?? []).filter(x => x.classType == ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person).map(
        (req) => RequirementPersonInput.fromRequirementSpecification(req as ApplicationModelsApiModelsApiRequirementSpecificationPerson, mainLanguage)
      );
      this.requirementMaterials = (project.requirementSpecifications ?? []).filter(x => x.classType == ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material).flatMap(
        (req) => RequirementMaterialInput.fromRequirementSpecification(req, mainLanguage)
      );
      this.requirementsMoney = (project.requirementSpecifications ?? []).filter(x => x.classType == ApplicationModelsApiModelsApiRequirementSpecificationTypes.Money).flatMap(
        (req) => RequirementMoneyInput.fromRequirementSpecification(req, mainLanguage)
      );
      this.selectedTags = (project.projectTags ?? []).map(x => {
        const tagNameTranslations = TranslationValue.arrayFromApiTranslationValues(x.tagNameTranslations ?? []);
        return new SelectOption(TranslationValue.getTranslationIfExist(x.tagName ?? "", tagNameTranslations, mainLanguage), null, x.entityId ?? null, tagNameTranslations, tagNameTranslations);
      }).filter(x => !!x.value);

      this.loadContactSpecificationsFromApi(project.contactSpecifications ?? [], mainLanguage);
      const shortDescriptionObj = project.descriptionSpecifications?.find(
          (desc) => desc.type?.name === "shortDescription"
      );
        const longDescriptionObj = project.descriptionSpecifications?.find(
            (desc) => desc.type?.name === "longDescription"
        );
        
        this.shortDescriptionTranslations = TranslationValue.arrayFromApiTranslationValues(shortDescriptionObj?.content?.contentTranslations ?? []);
        this.shortDescription = TranslationValue.getTranslationIfExist(shortDescriptionObj?.content?.rawContentString ?? "", this.shortDescriptionTranslations, mainLanguage);
          
        this.shortDescriptionEntityId = shortDescriptionObj?.entityId ?? null; 
        this.shortDescriptionTypeEntityId = shortDescriptionObj?.type?.entityId ?? null; 
            
            this.longDescriptionTranslations = TranslationValue.arrayFromApiTranslationValues(longDescriptionObj?.content?.contentTranslations ?? []);
      this.longDescription =
          TranslationValue.getTranslationIfExist(longDescriptionObj?.content?.rawContentString ?? "", this.longDescriptionTranslations, mainLanguage);
        this.longDescriptionEntityId = longDescriptionObj?.entityId ?? null;
        this.longDescriptionTypeEntityId = longDescriptionObj?.type?.entityId ?? null;
      this.uploadedImages = project?.graphicsSpecifications?.map(x => UploadedImage.fromApi(x, apiBasePath, this.entityId!)) ?? [];
      this.loadProjectVisibilityFromApi(project.visibility ?? "Unkown");
    }  
    async buildRequest(mainLanguage: Language): Promise<ApplicationModelsApiModelsApiProjectBody>{      
      const graphicsSpecifications: ApplicationModelsApiModelsApiGraphicsSpecification[] = [];
      for(const uploadedImage of this.uploadedImages){
        graphicsSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiGraphicsSpecification>({
          type: uploadedImage.getType(),
          entityId: uploadedImage.entityId ?? undefined,
          imageId: uploadedImage.imageId!
        }));
      }
        return {
          entityId: this.entityId ?? undefined,
          projectTitle: {
            rawContentString: TranslationValue.getTranslationIfExist(this.projectTitle, this.projectTitleTranslations, mainLanguage),
            contentTranslations: TranslationValue.toApiTranslationValues(this.projectTitleTranslations)
          },
          connectedOrganizations: [],
          connectedOrganizationsSameAsOwner: false,
          contactSpecifications: this.getContactSpecifications(mainLanguage),
          contributors: [],
          descriptionSpecifications: [ObjectCreator.Create<ApplicationModelsApiModelsApiDescriptionSpecification>({
              entityId: this.shortDescriptionEntityId ?? undefined,
            type: {
              name: "shortDescription",
                entityId: this.shortDescriptionTypeEntityId ?? undefined,
              descriptionTitle: {
                rawContentString: "short description",
                contentTranslations: []
              }
            },
            content: {
              rawContentString: TranslationValue.getTranslationIfExist(this.shortDescription, this.shortDescriptionTranslations, mainLanguage),
              contentTranslations: TranslationValue.toApiTranslationValues(this.shortDescriptionTranslations)
            }
          }),
          ObjectCreator.Create<ApplicationModelsApiModelsApiDescriptionSpecification>({
              entityId: this.longDescriptionEntityId ?? undefined,
            type: {
              name: "longDescription",
                entityId: this.longDescriptionTypeEntityId ?? undefined,
              descriptionTitle: {
                rawContentString: "long description",
                contentTranslations: []
              }
            },
            content: {
              rawContentString: TranslationValue.getTranslationIfExist(this.longDescription, this.longDescriptionTranslations, mainLanguage),
              contentTranslations: TranslationValue.toApiTranslationValues(this.longDescriptionTranslations)
            }
          })],
          graphicsSpecifications: graphicsSpecifications,
          locationSpecifications: this.locations.map(x => x.toLocationSpecification(mainLanguage)).filter(x => !!x),
          phase: this.getProjectPhaseForApi(),
          projectName: TranslationValue.getTranslationIfExist(this.projectName, this.projectNameTranslations, mainLanguage),
          projectNameTranslations: TranslationValue.toApiTranslationValues(this.projectNameTranslations),
          projectTags: this.selectedTags.map(x => ObjectCreator.Create<ApplicationModelsApiModelsApiProjectTag>({
              tagName: TranslationValue.getTranslationIfExist(x?.text ?? x?.value ?? "", x.textTranslations, mainLanguage),
              entityId: x?.entityId ?? undefined,
              tagNameTranslations: TranslationValue.toApiTranslationValues(x.textTranslations)
          })).filter(x => !!x),
          relatedProjects: [],
          timeSpecifications: this.projectTimes.map(x => x.toTimeSpecification()).filter(x => !!x),
          requirementSpecifications: this.getRequirementSpecifications(mainLanguage),
          visibility: this.getProjectVisibilityForApi(),
          type: this.getProjectTypeForApi()
        };
      }
    
      getRequirementSpecifications(mainLanguage: Language): ApplicationModelsApiModelsApiRequirementSpecification[]{
        const result: ApplicationModelsApiModelsApiRequirementSpecification[] = [];
        result.push(...this.requirementMaterials.map(x => x.toRequirementMaterialSpecifications(mainLanguage)));
        result.push(...this.requirementPersons.map(x => x.toRequirementPersonSpecification(mainLanguage)));
        result.push(...this.requirementsMoney.map(x => x.toRequirementMoneySpecification(mainLanguage)));
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
    
      loadContactSpecificationsFromApi(contactSpecifications: ApplicationModelsApiModelsApiContactSpecification[], mainLanguage: Language){
        const contactNameObj = contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PersonalName) as ApplicationModelsApiModelsApiContactSpecificationPersonalName;
        this.contactNameTranslations = TranslationValue.arrayFromApiTranslationValues(contactNameObj?.personalNameTranslations ?? []);
        this.contactName = TranslationValue.getTranslationIfExist(contactNameObj?.personalName ?? "", this.contactNameTranslations, mainLanguage);
        this.contactNameEntityId = contactNameObj?.entityId ?? null;
        const organisationNameObj = contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.OrganisationName) as ApplicationModelsApiModelsApiContactSpecificationOrganisationName;
        this.organisationNameTranslations = TranslationValue.arrayFromApiTranslationValues(organisationNameObj?.organisationNameTranslations ?? []);
        this.organisationName = TranslationValue.getTranslationIfExist(organisationNameObj?.organisationName ?? "", this.organisationNameTranslations, mainLanguage);
        this.contactOrganisationNameEntityId = organisationNameObj?.entityId ?? null;
        const contactPhoneObj = contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PhoneNumber) as ApplicationModelsApiModelsApiContactSpecificationPhoneNumber;
        this.contactPhoneTranslations = TranslationValue.arrayFromApiTranslationValues(contactPhoneObj?.phoneNumber?.phoneNumberTextTranslations ?? []);
        this.contactPhone = TranslationValue.getTranslationIfExist(contactPhoneObj?.phoneNumber?.phoneNumberText ?? "", this.contactPhoneTranslations, mainLanguage);
        this.contactPhoneEntityId = contactPhoneObj?.entityId ?? null;
        const contactMailObj = contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.MailAddress) as ApplicationModelsApiModelsApiContactSpecificationMailAddress;
        this.contactMailTranslations = TranslationValue.arrayFromApiTranslationValues(contactMailObj?.mailAddress?.mailTranslations ?? []);
        this.contactMail = TranslationValue.getTranslationIfExist(contactMailObj?.mailAddress?.mail ?? "", this.contactMailTranslations, mainLanguage);
        this.contactMailEntityId = contactMailObj?.entityId ?? null;
        
        this.contactSpecifications = contactSpecifications.map(x => {
          if(x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.Paypal){
            return ContactSpecification.fromContactSpecificationPaypal(x as ApplicationModelsApiModelsApiContactSpecificationPaypal, mainLanguage);
          }
          
          if(x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.BankAccount){
            return ContactSpecification.fromContactSpecificationBankAccount(x as ApplicationModelsApiModelsApiContactSpecificationBankAccount, mainLanguage);
          }
          
          if(x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.Website){
            return ContactSpecification.fromContactSpecificationWebsite(x as ApplicationModelsApiModelsApiContactSpecificationWebsite, mainLanguage);
          }
          return null;
        }).filter(x => !!x);
      }
      
      getContactSpecifications(mainLanguage: Language){
        const contactSpecifications: ApplicationModelsApiModelsApiContactSpecification[] = []
        if(this.contactPhone){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPhoneNumber>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.PhoneNumber,
              entityId: this.contactPhoneEntityId ?? undefined,
            phoneNumber: {
              phoneNumberText: TranslationValue.getTranslationIfExist(this.contactPhone, this.contactPhoneTranslations, mainLanguage),
              phoneNumberTextTranslations: TranslationValue.toApiTranslationValues(this.contactPhoneTranslations)
            }
          }));
        }
        if(this.contactMail){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationMailAddress>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.MailAddress,
              entityId: this.contactMailEntityId ?? undefined,
            mailAddress: {
              mail: TranslationValue.getTranslationIfExist(this.contactMail,this.contactMailTranslations, mainLanguage),
              mailTranslations: TranslationValue.toApiTranslationValues(this.contactMailTranslations)
            }
          }));
        }
        if(this.contactName){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPersonalName>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.PersonalName,
              entityId: this.contactNameEntityId ?? undefined,
            personalName: TranslationValue.getTranslationIfExist(this.contactName,this.contactNameTranslations, mainLanguage),
            personalNameTranslations: TranslationValue.toApiTranslationValues(this.contactNameTranslations)
          }))
        }
        if(this.organisationName){
          contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationOrganisationName>({
            classType: ApplicationModelsApiModelsApiContactSpecificationTypes.OrganisationName,
              entityId: this.contactOrganisationNameEntityId ?? undefined,
            organisationName: TranslationValue.getTranslationIfExist(this.organisationName,this.organisationNameTranslations, mainLanguage),
            organisationNameTranslations: TranslationValue.toApiTranslationValues(this.organisationNameTranslations)
          }))
        }

        for(const contactSpecification of this.contactSpecifications){
          if(contactSpecification.contactSpecificationType === "bankAccount"){
            contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationBankAccount>({
              classType: ApplicationModelsApiModelsApiContactSpecificationTypes.BankAccount,
                entityId: contactSpecification.entityId ?? undefined,
              bankAccount: {
                accountName: TranslationValue.getTranslationIfExist(contactSpecification.bankAccountName,contactSpecification.bankAccountNameTranslations, mainLanguage),
                accountNameTranslations: TranslationValue.toApiTranslationValues(contactSpecification.bankAccountNameTranslations),
                bic: {
                  bicName: contactSpecification.bankAccountBic
                },
                iban: {
                  ibanName: contactSpecification.bankAccountIban
                },
                reference: TranslationValue.getTranslationIfExist(contactSpecification.bankAccountReference,contactSpecification.bankAccountReferenceTranslations, mainLanguage),
                referenceTranslations: TranslationValue.toApiTranslationValues(contactSpecification.bankAccountReferenceTranslations)
              }
            }))
          }
          if(contactSpecification.contactSpecificationType === "paypalAccount"){
            contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPaypal>({
              classType: ApplicationModelsApiModelsApiContactSpecificationTypes.Paypal,
                entityId: contactSpecification.entityId ?? undefined,
              paypalAddress: {
                mail: TranslationValue.getTranslationIfExist(contactSpecification.paypalAddress,contactSpecification.paypalAddressTranslations, mainLanguage),
                mailTranslations: TranslationValue.toApiTranslationValues(contactSpecification.paypalAddressTranslations)
              },
              paypalMeAddress: {
                rawUrl: TranslationValue.getTranslationIfExist(contactSpecification.paypalMeAddress,contactSpecification.paypalMeAddressTranslations, mainLanguage),
                urlTranslations: TranslationValue.toApiTranslationValues(contactSpecification.paypalMeAddressTranslations)
              }
            }))
          }
          if(contactSpecification.contactSpecificationType === "website"){
            contactSpecifications.push(ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationWebsite>({
              classType: ApplicationModelsApiModelsApiContactSpecificationTypes.Website,
                entityId: contactSpecification.entityId ?? undefined,
              website: {
                rawUrl: TranslationValue.getTranslationIfExist(contactSpecification.website,contactSpecification.websiteTranslations, mainLanguage),
                urlTranslations: TranslationValue.toApiTranslationValues(contactSpecification.websiteTranslations)
              }
            }))
          }
        }
        return contactSpecifications;
      }
}