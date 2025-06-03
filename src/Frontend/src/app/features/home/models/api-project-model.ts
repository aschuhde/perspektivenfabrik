import {ApplicationModelsApiModelsApiProject} from "../../../server/model/applicationModelsApiModelsApiProject";
import {GalleryImage} from "../../../shared/models/gallery-image";
import {
  ApplicationModelsApiModelsApiLocationSpecification
} from "../../../server/model/applicationModelsApiModelsApiLocationSpecification";
import {
  ApplicationModelsApiModelsApiTimeSpecification
} from "../../../server/model/applicationModelsApiModelsApiTimeSpecification";
import {ApplicationModelsApiModelsApiProjectTag} from "../../../server/model/applicationModelsApiModelsApiProjectTag";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationMaterial
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMaterial";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationMoney
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMoney";
import {ObjectCreator} from "../../../shared/tools/object-creator";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationTypes
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import {formatMoney} from "../../../shared/tools/formatting";
import {getShortYear, parseMoneyWithFallback} from "../../../shared/tools/parsing";
import {
  ApplicationModelsApiModelsApiContactSpecificationTypes
} from "../../../server/model/applicationModelsApiModelsApiContactSpecificationTypes";
import {
  ApplicationModelsApiModelsApiContactSpecificationPersonalName
} from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPersonalName";
import {
  ApplicationModelsApiModelsApiContactSpecificationOrganisationName
} from "../../../server/model/applicationModelsApiModelsApiContactSpecificationOrganisationName";
import {
  ApplicationModelsApiModelsApiContactSpecificationPhoneNumber
} from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPhoneNumber";
import {
  ApplicationModelsApiModelsApiContactSpecificationMailAddress
} from "../../../server/model/applicationModelsApiModelsApiContactSpecificationMailAddress";
import {
  ApplicationModelsApiModelsApiContactSpecificationWebsite
} from "../../../server/model/applicationModelsApiModelsApiContactSpecificationWebsite";
import {
  ApplicationModelsApiModelsApiLocationSpecificationTypes
} from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationTypes";
import {
  ApplicationModelsApiModelsApiLocationSpecificationAddress
} from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationAddress";
import {AddressConverter} from "../../../shared/tools/address-converter";
import {
  ApplicationModelsApiModelsApiLocationSpecificationRegion
} from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationRegion";
import {
  ApplicationModelsApiModelsApiLocationSpecificationCoordinates
} from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationCoordinates";
import {formatDate, formatNumber} from "@angular/common";
import {
  ApplicationModelsApiModelsApiTimeSpecificationTypes
} from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationTypes";
import {
  ApplicationModelsApiModelsApiTimeSpecificationDateTime
} from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationDateTime";
import {
  ApplicationModelsApiModelsApiTimeSpecificationDate
} from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationDate";
import {
  ApplicationModelsApiModelsApiTimeSpecificationMonth
} from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationMonth";
import {getMonthName} from "../../../shared/tools/date-tools";
import {
  ApplicationModelsApiModelsApiTimeSpecificationPeriod
} from "../../../server/model/applicationModelsApiModelsApiTimeSpecificationPeriod";
import {
  ApplicationModelsApiModelsApiRequirementSpecification
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecification";
import {LocaleDataProvider} from "../../../core/services/locale-data.service";
import {
  ApplicationModelsApiModelsApiSkillSpecification
} from "../../../server/model/applicationModelsApiModelsApiSkillSpecification";
import {distinctBy} from "../../../shared/tools/array-tools";
import { ApplicationModelsApiModelsApiLocationSpecificationName } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationName";
import { TranslateService } from "@ngx-translate/core";
import {UploadedImage} from "../../../shared/models/uploaded-image";
import {DomainDataTypesFormattedContent} from "../../../server/model/domainDataTypesFormattedContent";
import {Language} from "../../../core/types/general-types";

export class ApiProjectModel {
  project: ApplicationModelsApiModelsApiProject | null = null;
  shortDescription: DomainDataTypesFormattedContent | null = null;
  longDescription: DomainDataTypesFormattedContent | null = null;
  projectTitle: DomainDataTypesFormattedContent | null = null;
  projectImages: GalleryImage[] = [];
  locationSpecifications: ApplicationModelsApiModelsApiLocationSpecification[] = [];
  timeSpecifications: ApplicationModelsApiModelsApiTimeSpecification[] = [];
  tags: ApplicationModelsApiModelsApiProjectTag[] = [];
  requirementSpecificationPersons: ApplicationModelsApiModelsApiRequirementSpecificationPerson[] = [];
  requirementSpecificationPersonsFlat: ApplicationModelsApiModelsApiRequirementSpecificationPerson[] = [];
  requirementSpecificationMaterials: ApplicationModelsApiModelsApiRequirementSpecificationMaterial[] = [];
  requirementSpecificationMaterialsFlat: ApplicationModelsApiModelsApiRequirementSpecificationMaterial[] = [];
  requirementSpecificationMoney: ApplicationModelsApiModelsApiRequirementSpecificationMoney[] = [];
  requirementSpecificationMoneySummed: ApplicationModelsApiModelsApiRequirementSpecificationMoney | null = null;
  contactPersonalName: ApplicationModelsApiModelsApiContactSpecificationPersonalName | null = null;
  contactOrganisationName: ApplicationModelsApiModelsApiContactSpecificationOrganisationName | null = null;
  contactPhone: ApplicationModelsApiModelsApiContactSpecificationPhoneNumber | null = null;
  contactMailAddress: ApplicationModelsApiModelsApiContactSpecificationMailAddress | null = null;
  contactWebsites: ApplicationModelsApiModelsApiContactSpecificationWebsite[] = [];
  thumbnailDescription: DomainDataTypesFormattedContent | null = null;

  loadFromApiProject(apiProject: ApplicationModelsApiModelsApiProject, localeDataProvider: LocaleDataProvider, apiBasePath: string) {
    this.project = apiProject;
    this.shortDescription = this.project?.descriptionSpecifications?.find(x => x.type?.name === "shortDescription")?.content ?? null;
    this.longDescription = this.project?.descriptionSpecifications?.find(x => x.type?.name === "longDescription")?.content ?? null;
    this.thumbnailDescription = this.project?.descriptionSpecifications?.find(x => x.type?.name === "thumbnailDescription")?.content ?? this.shortDescription ?? null;
    this.projectTitle = this.project?.projectTitle ?? null;
    this.projectImages = this.project?.graphicsSpecifications?.filter(x => x.type !== 'Logo').map(x => ObjectCreator.Create<GalleryImage>({
      imageName: "",
      src: UploadedImage.buildUrl(apiBasePath, this.project?.entityId ?? null, x.imageId ?? null),
      alt: "",
    })) ?? [];
    this.locationSpecifications = this.project?.locationSpecifications ?? [];
    this.timeSpecifications = this.project?.timeSpecifications ?? [];
    this.tags = this.project?.projectTags ?? [];
    this.requirementSpecificationPersons = this.project?.requirementSpecifications?.filter(x => x.classType === ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person) ?? [];
    this.requirementSpecificationPersonsFlat = distinctBy(this.requirementSpecificationPersons.flatMap(person => {
      const personSpecification = person as ApplicationModelsApiModelsApiRequirementSpecificationPerson;
      if(personSpecification && personSpecification?.skillSpecifications?.length === 0){
        return [ObjectCreator.Create<ApplicationModelsApiModelsApiRequirementSpecificationPerson>({
          skillSpecifications: [ObjectCreator.Create<ApplicationModelsApiModelsApiSkillSpecification>({
            name: localeDataProvider.locale === "it-IT" ? "Aiutanti" : "Helfer*innen",
            title: {
              rawContentString: localeDataProvider.locale === "it-IT" ? "Aiutanti" : "Helfer*innen",
            }
          })],
          locationSpecifications: personSpecification.locationSpecifications,
          timeSpecifications: personSpecification.timeSpecifications,
          classType: personSpecification.classType,
          quantitySpecification: personSpecification.quantitySpecification,
          locationSpecificationsSameAsProject: personSpecification.locationSpecificationsSameAsProject,
          timeSpecificationSameAsProject: personSpecification.timeSpecificationSameAsProject,
          workAmountSpecification: personSpecification.workAmountSpecification
        })];
      }
      
      return personSpecification?.skillSpecifications?.map(x => {
        return ObjectCreator.Create<ApplicationModelsApiModelsApiRequirementSpecificationPerson>({
          skillSpecifications: [x],
          locationSpecifications: personSpecification.locationSpecifications,
          timeSpecifications: personSpecification.timeSpecifications,
          classType: personSpecification.classType,
          quantitySpecification: personSpecification.quantitySpecification,
          locationSpecificationsSameAsProject: personSpecification.locationSpecificationsSameAsProject,
          timeSpecificationSameAsProject: personSpecification.timeSpecificationSameAsProject,
          workAmountSpecification: personSpecification.workAmountSpecification
        })
      }) ?? [];
    }), x => x?.skillSpecifications ? x.skillSpecifications[0]?.name : "");
    this.requirementSpecificationMaterials = this.project?.requirementSpecifications?.filter(x => x.classType === ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material) ?? [];
    this.requirementSpecificationMaterialsFlat = this.requirementSpecificationMaterials.flatMap(material => {
      const materialSpecification = material as ApplicationModelsApiModelsApiRequirementSpecificationMaterial;
      return materialSpecification?.materialSpecifications?.map(x => {
        return ObjectCreator.Create<ApplicationModelsApiModelsApiRequirementSpecificationMaterial>({
          materialSpecifications: [x],
          locationSpecifications: materialSpecification.locationSpecifications,
          timeSpecifications: materialSpecification.timeSpecifications,
          classType: materialSpecification.classType,
          quantitySpecification: {
            value: x.amountValue
          },
          locationSpecificationsSameAsProject: materialSpecification.locationSpecificationsSameAsProject,
          timeSpecificationSameAsProject: materialSpecification.timeSpecificationSameAsProject
        });
      }) ?? [];
    });
    this.requirementSpecificationMoney = this.project?.requirementSpecifications?.filter(x => x.classType === ApplicationModelsApiModelsApiRequirementSpecificationTypes.Money) ?? [];
    this.requirementSpecificationMoneySummed = ObjectCreator.Create<ApplicationModelsApiModelsApiRequirementSpecificationMoney>({
      classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Money,
      timeSpecificationSameAsProject: !this.requirementSpecificationMoney.find(x => !x.timeSpecificationSameAsProject),
      quantitySpecification: {
        value: formatMoney(this.requirementSpecificationMoney.map(x => parseMoneyWithFallback(x.quantitySpecification?.value ?? "0", 0)).reduce((a, b) => {
          return (a ?? 0) + (b ?? 0);
        }, 0), localeDataProvider.locale, "euro")
      },
      timeSpecifications: []
    });
    if((parseMoneyWithFallback(this.requirementSpecificationMoneySummed.quantitySpecification?.value, 0) ?? 0) <= 0){
      this.requirementSpecificationMoneySummed = null;
    }
    this.contactPersonalName = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PersonalName) as ApplicationModelsApiModelsApiContactSpecificationPersonalName) ?? null;
    this.contactOrganisationName = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.OrganisationName) as ApplicationModelsApiModelsApiContactSpecificationOrganisationName) ?? null;
    this.contactPhone = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PhoneNumber) as ApplicationModelsApiModelsApiContactSpecificationPhoneNumber) ?? null;
    this.contactMailAddress = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.MailAddress) as ApplicationModelsApiModelsApiContactSpecificationMailAddress) ?? null;
    this.contactWebsites = this.project?.contactSpecifications?.filter(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.Website).map(x => (x as ApplicationModelsApiModelsApiContactSpecificationWebsite) ?? null).filter(x => x) ?? [];
    return this;
  }
  
  
  static getLocationSpecificationShortName(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification, localeDataProvider: LocaleDataProvider, translateService: TranslateService){
    switch(locationSpecification.classType){
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Address:
        const address = (locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationAddress).postalAddress;
        return address ? AddressConverter.getShortName(address, localeDataProvider.language) : "-";
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Name:
        const name = (locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationName).postalAddress;
        return name ? AddressConverter.getShortName(name, localeDataProvider.language) : "-";
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Region:
        const region = (locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationRegion).region;
        return region?.regionName ?? "-";
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates:
        const coordinates = (locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationCoordinates).coordinates;
        if(!coordinates?.lat || !coordinates?.lon){
          return null;
        }
        return `${formatNumber(coordinates?.lat, localeDataProvider.locale, "1.3-3")}, ${formatNumber(coordinates?.lon, localeDataProvider.locale, "1.3-3")}`;
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote:
        return translateService.instant("input-location.remote");
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.EntireProvince:
        return translateService.instant("input-location.entireProvince");
    }
    return null;
  }

  getLocationSpecificationIconName(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification): string {
    switch(locationSpecification.classType){
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Address:
        return "distance";
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Region:
        return "distance";
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates:
        return "distance";
      case ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote:
        return "computer";
    }
    return "";
  }

  static getTimeSpecificationShortName(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification, localeDataProvider: LocaleDataProvider): string{
    switch (timeSpecification.classType){
      case ApplicationModelsApiModelsApiTimeSpecificationTypes.DateTime:
        const dateTime = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationDateTime).date;
        return dateTime ? formatDate(dateTime, localeDataProvider.dateTimeFormat, localeDataProvider.locale) : "";
      case ApplicationModelsApiModelsApiTimeSpecificationTypes.Date:
        const date = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationDate).date;
        return date ? formatDate(date, localeDataProvider.dateFormat, localeDataProvider.locale) : "";
      case ApplicationModelsApiModelsApiTimeSpecificationTypes.Month:
        const month = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationMonth).month;
        return month?.monthFromOneToTwelve && month?.year?.yearNumber ? `${getMonthName(month.monthFromOneToTwelve, localeDataProvider.locale)} ${getShortYear(month.year.yearNumber)}` : "";
      case ApplicationModelsApiModelsApiTimeSpecificationTypes.Period:
        const period = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationPeriod);
        return period?.start && period?.end ? `${this.getTimeSpecificationShortName(period.start, localeDataProvider)} - ${this.getTimeSpecificationShortName(period.end, localeDataProvider)}` : "";
    }
    return "";
  }
  getTimeSpecificationIcon(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification){
    switch (timeSpecification.classType){
      case ApplicationModelsApiModelsApiTimeSpecificationTypes.DateTime:
        return "calendar_clock";
      case ApplicationModelsApiModelsApiTimeSpecificationTypes.Date:
        return "event";
      case ApplicationModelsApiModelsApiTimeSpecificationTypes.Month:
        return "calendar_month";
      case ApplicationModelsApiModelsApiTimeSpecificationTypes.Period:
        return "date_range";
    }
    return null;
  }
  getTagShortName(tag: ApplicationModelsApiModelsApiProjectTag, language: Language){
    const tagNameTranslations = tag.tagNameTranslations?.find(x => x.languageCode == language);
    if(tagNameTranslations && tagNameTranslations.value){
      return tagNameTranslations.value;
    }
    return tag?.tagName;
  }

  getRequirementSpecificationPersonShortName(requirementSpecificationPerson: ApplicationModelsApiModelsApiRequirementSpecificationPerson | undefined, language: Language){
    if(!requirementSpecificationPerson){
      return "";
    }
    if (requirementSpecificationPerson.classType !== ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person){
      return "";
    }
    const personSpecification = requirementSpecificationPerson as ApplicationModelsApiModelsApiRequirementSpecificationPerson;
    if((personSpecification.skillSpecifications?.length ?? 0) === 0){
      return "";
    }
    let skillSpecification = personSpecification?.skillSpecifications![0];
    const contentTranslation = skillSpecification.title?.contentTranslations?.find(x => x.languageCode == language);
    if(contentTranslation && contentTranslation.value){
      return contentTranslation.value;
    }
    const nameTranslation = skillSpecification.nameTranslations?.find(x => x.languageCode == language);
    if(nameTranslation && nameTranslation.value){
      return nameTranslation.value;
    }
    return skillSpecification.title?.rawContentString ?? skillSpecification.name ?? "";
  }

  getRequirementSpecificationMaterialShortName(requirementSpecificationMaterial: ApplicationModelsApiModelsApiRequirementSpecification, language: Language){
    if (requirementSpecificationMaterial.classType !== ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material){
      return "";
    }
    const materialSpecification = requirementSpecificationMaterial as ApplicationModelsApiModelsApiRequirementSpecificationMaterial;
    if((materialSpecification.materialSpecifications?.length ?? 0) === 0){
      return "";
    }
    const materialSpecificationObj = materialSpecification?.materialSpecifications![0];
    const contentTranslation = materialSpecificationObj.title?.contentTranslations?.find(x => x.languageCode == language);
    if(contentTranslation && contentTranslation.value){
      return contentTranslation.value;
    }
    const nameTranslation = materialSpecificationObj.nameTranslations?.find(x => x.languageCode == language);
    if(nameTranslation && nameTranslation.value){
      return nameTranslation.value;
    }
    return materialSpecificationObj.title?.rawContentString ?? materialSpecificationObj.name ?? "";
  }

  getRequirementSpecificationMoneyShortName(requirementSpecificationMoney: ApplicationModelsApiModelsApiRequirementSpecification, localeDataProvider: LocaleDataProvider){
    if (requirementSpecificationMoney.classType !== ApplicationModelsApiModelsApiRequirementSpecificationTypes.Money){
      return "";
    }
    const moneySpecification = requirementSpecificationMoney as ApplicationModelsApiModelsApiRequirementSpecificationMoney;
    if(!moneySpecification.quantitySpecification?.value){
      return "";
    }
    return formatMoney(moneySpecification.quantitySpecification.value, localeDataProvider.locale, "euro");
  }

  getThumbnailUrl(apiBasePath: string) {
    const graphicSpecification = this.project?.graphicsSpecifications?.find(x => x.type === "Header") ??
      this.project?.graphicsSpecifications?.find(x => x.type !== "Logo") ??
      this.project?.graphicsSpecifications?.find(_ => true);
    if(!graphicSpecification){
      return "";
    }
    return UploadedImage.buildUrl(apiBasePath, this.project?.entityId ?? null, graphicSpecification.imageId ?? null);
  }

  needsMoney() {
    return !!this.requirementSpecificationMoney.find(x => (parseMoneyWithFallback(x.quantitySpecification?.value ?? "0", 0) ?? 0) > 0);
  }
  
  getShortDescriptionContent(language: Language){
    if(!this.shortDescription) return "";

    const contentTranslation = this.shortDescription.contentTranslations?.find(x => x.languageCode == language);
    if(contentTranslation && contentTranslation.value){
      return contentTranslation.value;
    }
    return this.shortDescription.rawContentString ?? "";
  }
  getLongDescriptionContent(language: Language){
    if(!this.longDescription) return "";

    const contentTranslation = this.longDescription.contentTranslations?.find(x => x.languageCode == language);
    if(contentTranslation && contentTranslation.value){
      return contentTranslation.value;
    }
    return this.longDescription.rawContentString ?? "";
  }

  getThumbnailDescriptionContent(language: Language){
    if(!this.thumbnailDescription) return "";

    const contentTranslation = this.thumbnailDescription.contentTranslations?.find(x => x.languageCode == language);
    if(contentTranslation && contentTranslation.value){
      return contentTranslation.value;
    }
    return this.thumbnailDescription.rawContentString ?? "";
  }

  getContactPersonalNameContent(language: Language){
    if(!this.contactPersonalName) return "";

    const personalNameTranslation = this.contactPersonalName.personalNameTranslations?.find(x => x.languageCode == language);
    if(personalNameTranslation && personalNameTranslation.value){
      return personalNameTranslation.value;
    }
    return this.contactPersonalName.personalName ?? "";
  }

  getContactOrganisationNameContent(language: Language){
    if(!this.contactOrganisationName) return "";

    const organisationNameTranslation = this.contactOrganisationName.organisationNameTranslations?.find(x => x.languageCode == language);
    if(organisationNameTranslation && organisationNameTranslation.value){
      return organisationNameTranslation.value;
    }
    return this.contactOrganisationName.organisationName ?? "";
  }

  getContactPhoneNumberContent(language: Language){
    if(!this.contactPhone?.phoneNumber) return "";

    const phoneNumberTranslation = this.contactPhone?.phoneNumber?.phoneNumberTextTranslations?.find(x => x.languageCode == language);
    if(phoneNumberTranslation && phoneNumberTranslation.value){
      return phoneNumberTranslation.value;
    }
    return this.contactPhone.phoneNumber.phoneNumberText ?? "";
  }

  getContactMailAddressContent(language: Language){
    if(!this.contactMailAddress?.mailAddress) return "";

    const mailAddressTranslation = this.contactMailAddress?.mailAddress?.mailTranslations?.find(x => x.languageCode == language);
    if(mailAddressTranslation && mailAddressTranslation.value){
      return mailAddressTranslation.value;
    }
    return this.contactMailAddress.mailAddress.mail ?? "";
  }

  getProjectTitleContent(language: Language){
    if(!this.projectTitle) return "";

    const projectTitleTranslation = this.projectTitle.contentTranslations?.find(x => x.languageCode == language);
    if(projectTitleTranslation && projectTitleTranslation.value){
      return projectTitleTranslation.value;
    }
    return this.projectTitle.rawContentString ?? "";
  }
}