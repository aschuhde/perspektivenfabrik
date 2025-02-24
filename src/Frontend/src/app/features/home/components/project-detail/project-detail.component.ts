import {Component, inject, model, SimpleChanges} from '@angular/core';
import { ApplicationModelsApiModelsApiProject } from '../../../../server/model/applicationModelsApiModelsApiProject';
import { ObjectCreator } from '../../../../shared/tools/object-creator';
import { GalleryImage } from '../../../../shared/models/gallery-image';
import { ApplicationModelsApiModelsApiLocationSpecification } from '../../../../server/model/applicationModelsApiModelsApiLocationSpecification';
import { ApplicationModelsApiModelsApiTimeSpecification } from '../../../../server/model/applicationModelsApiModelsApiTimeSpecification';
import { ApplicationModelsApiModelsApiProjectTag } from '../../../../server/model/applicationModelsApiModelsApiProjectTag';
import { ApplicationModelsApiModelsApiRequirementSpecificationPerson } from '../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson';
import { ApplicationModelsApiModelsApiRequirementSpecification } from '../../../../server/model/applicationModelsApiModelsApiRequirementSpecification';
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from '../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes';
import { ApplicationModelsApiModelsApiContactSpecificationTypes } from '../../../../server/model/applicationModelsApiModelsApiContactSpecificationTypes';
import { ApplicationModelsApiModelsApiContactSpecificationPersonalName } from '../../../../server/model/applicationModelsApiModelsApiContactSpecificationPersonalName';
import { ApplicationModelsApiModelsApiContactSpecificationMailAddress } from '../../../../server/model/applicationModelsApiModelsApiContactSpecificationMailAddress';
import { ApplicationModelsApiModelsApiContactSpecificationOrganisationName } from '../../../../server/model/applicationModelsApiModelsApiContactSpecificationOrganisationName';
import { ApplicationModelsApiModelsApiContactSpecificationPhoneNumber } from '../../../../server/model/applicationModelsApiModelsApiContactSpecificationPhoneNumber';
import { ApplicationModelsApiModelsApiContactSpecificationWebsite } from '../../../../server/model/applicationModelsApiModelsApiContactSpecificationWebsite';
import { ImageGalleryComponent } from '../../../../shared/components/image-gallery/image-gallery.component';
import {
    ApplicationModelsApiModelsApiLocationSpecificationTypes
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationTypes";
import {
    ApplicationModelsApiModelsApiLocationSpecificationAddress
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationAddress";
import {
    ApplicationModelsApiModelsApiLocationSpecificationRegion
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationRegion";
import {
    ApplicationModelsApiModelsApiLocationSpecificationCoordinates
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationCoordinates";
import {formatDate, formatNumber} from "@angular/common";
import { ApplicationModelsApiModelsApiTimeSpecificationTypes } from '../../../../server/model/applicationModelsApiModelsApiTimeSpecificationTypes';
import {
    ApplicationModelsApiModelsApiTimeSpecificationDateTime
} from "../../../../server/model/applicationModelsApiModelsApiTimeSpecificationDateTime";
import {
    ApplicationModelsApiModelsApiTimeSpecificationDate
} from "../../../../server/model/applicationModelsApiModelsApiTimeSpecificationDate";
import {
    ApplicationModelsApiModelsApiTimeSpecificationMonth
} from "../../../../server/model/applicationModelsApiModelsApiTimeSpecificationMonth";
import {
    ApplicationModelsApiModelsApiTimeSpecificationPeriod
} from "../../../../server/model/applicationModelsApiModelsApiTimeSpecificationPeriod";
import {
    ApplicationModelsApiModelsApiRequirementSpecificationMaterial
} from "../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMaterial";
import {
    ApplicationModelsApiModelsApiRequirementSpecificationMoney
} from "../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMoney";
import {getMonthName} from "../../../../shared/tools/date-tools";
import { AddressConverter } from '../../../../shared/tools/address-converter';
import { formatMoney } from '../../../../shared/tools/formatting';
import { getShortYear, parseMoneyWithFallback } from '../../../../shared/tools/parsing';
import {LocaleDataProvider} from "../../../../core/services/locale-data.service";

@Component({
  selector: 'app-project-detail',
  imports: [ImageGalleryComponent],
  templateUrl: './project-detail.component.html',
  styleUrl: './project-detail.component.scss'
})
export class ProjectDetailComponent {    
    apiProject = model.required<ApplicationModelsApiModelsApiProject | null>();
    localeDataProvider = inject(LocaleDataProvider)
    
    project: ApplicationModelsApiModelsApiProject | null = null;
    shortDescription: string = "";
    longDescription: string = "";
    projectTitle: string = "";
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
    contactPersonalName: string = "";
    contactOrganisationName: string = "";
    contactPhone: string = "";
    contactMailAddress: string = "";
    contactWebsite: string = "";

    ngOnChanges(changes: SimpleChanges) {
        if(changes["apiProject"]?.currentValue){
            this.project = this.apiProject();
            this.shortDescription = this.project?.descriptionSpecifications?.find(x => x.type?.name === "shortDescription")?.content?.rawContentString ?? "";
            this.longDescription = this.project?.descriptionSpecifications?.find(x => x.type?.name === "longDescription")?.content?.rawContentString ?? "";
            this.projectTitle = this.project?.projectTitle?.rawContentString ?? "";
            this.projectImages = this.project?.graphicsSpecifications?.filter(x => x.type !== 'Logo').map(x => ObjectCreator.Create<GalleryImage>({
                imageName: "",
                src: "data:image/png;base64, " + (x.content?.content ?? ""),
                alt: ""
            })) ?? [];
            this.locationSpecifications = this.project?.locationSpecifications ?? [];
            this.timeSpecifications = this.project?.timeSpecifications ?? [];
            this.tags = this.project?.projectTags ?? [];
            this.requirementSpecificationPersons = this.project?.requirementSpecifications?.filter(x => x.classType === ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person) ?? [];
            this.requirementSpecificationPersonsFlat = this.requirementSpecificationPersons.flatMap(person => {
                const personSpecification = person as ApplicationModelsApiModelsApiRequirementSpecificationPerson;
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
            });
            this.requirementSpecificationMaterials = this.project?.requirementSpecifications?.filter(x => x.classType === ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material) ?? [];
            this.requirementSpecificationMaterialsFlat = this.requirementSpecificationMaterials.flatMap(material => {
                const materialSpecification = material as ApplicationModelsApiModelsApiRequirementSpecificationMaterial;
                return materialSpecification?.materialSpecifications?.map(x => {
                    return ObjectCreator.Create<ApplicationModelsApiModelsApiRequirementSpecificationMaterial>({
                        materialSpecifications: [x],
                        locationSpecifications: materialSpecification.locationSpecifications,
                        timeSpecifications: materialSpecification.timeSpecifications,
                        classType: materialSpecification.classType,
                        quantitySpecification: materialSpecification.quantitySpecification,
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
                    }, 0), this.localeDataProvider.locale, "euro")
                },
                timeSpecifications: []
            });
            this.contactPersonalName = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PersonalName) as ApplicationModelsApiModelsApiContactSpecificationPersonalName)?.personalName ?? "";
            this.contactOrganisationName = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.OrganisationName) as ApplicationModelsApiModelsApiContactSpecificationOrganisationName)?.organisationName ?? "";
            this.contactPhone = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PhoneNumber) as ApplicationModelsApiModelsApiContactSpecificationPhoneNumber)?.phoneNumber?.phoneNumberText ?? "";
            this.contactMailAddress = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.MailAddress) as ApplicationModelsApiModelsApiContactSpecificationMailAddress)?.mailAddress?.mail ?? "";
            this.contactWebsite = (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.Website) as ApplicationModelsApiModelsApiContactSpecificationWebsite)?.website?.rawUrl ?? "";
        }
    }
    getLocationSpecificationShortName(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification){
        switch(locationSpecification.classType){
            case ApplicationModelsApiModelsApiLocationSpecificationTypes.Address:
                const address = (locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationAddress).postalAddress;
                return address ? AddressConverter.getShortName(address) : "-";
            case ApplicationModelsApiModelsApiLocationSpecificationTypes.Region:
                const region = (locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationRegion).region;
                return region?.regionName ?? "-";
            case ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates:
                const coordinates = (locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationCoordinates).coordinates;
                if(!coordinates?.lat || !coordinates?.lon){
                    return null;
                }
                return `${formatNumber(coordinates?.lat, this.localeDataProvider.locale, "1.3-3")}, ${formatNumber(coordinates?.lon, this.localeDataProvider.locale, "1.3-3")}`;
            case ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote:
                return "remote";
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

    getTimeSpecificationShortName(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification): string{
        switch (timeSpecification.classType){
            case ApplicationModelsApiModelsApiTimeSpecificationTypes.DateTime:
                const dateTime = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationDateTime).date;
                return dateTime ? formatDate(dateTime, this.localeDataProvider.dateTimeFormat, this.localeDataProvider.locale) : "";
            case ApplicationModelsApiModelsApiTimeSpecificationTypes.Date:
                const date = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationDate).date;
                return date ? formatDate(date, this.localeDataProvider.dateFormat, this.localeDataProvider.locale) : "";
            case ApplicationModelsApiModelsApiTimeSpecificationTypes.Month:
                const month = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationMonth).month;
                return month?.monthFromOneToTwelve && month?.year?.yearNumber ? `${getMonthName(month.monthFromOneToTwelve, this.localeDataProvider.locale)} ${getShortYear(month.year.yearNumber)}` : "";
            case ApplicationModelsApiModelsApiTimeSpecificationTypes.Period:
                const period = (timeSpecification as ApplicationModelsApiModelsApiTimeSpecificationPeriod);
                return period?.start && period?.end ? `${this.getTimeSpecificationShortName(period.start)} - ${this.getTimeSpecificationShortName(period.end)}` : "";
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
    getTagShortName(tag: ApplicationModelsApiModelsApiProjectTag){
        return tag.tagName;
    }

    getRequirementSpecificationPersonShortName(requirementSpecificationPerson: ApplicationModelsApiModelsApiRequirementSpecificationPerson | undefined){
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
        return personSpecification?.skillSpecifications![0].title?.rawContentString ?? personSpecification?.skillSpecifications![0].name ?? "";
    }

    getRequirementSpecificationMaterialShortName(requirementSpecificationMaterial: ApplicationModelsApiModelsApiRequirementSpecification){
        if (requirementSpecificationMaterial.classType !== ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material){
            return "";
        }
        const materialSpecification = requirementSpecificationMaterial as ApplicationModelsApiModelsApiRequirementSpecificationMaterial;
        if((materialSpecification.materialSpecifications?.length ?? 0) === 0){
            return "";
        }
        return materialSpecification?.materialSpecifications![0].title?.rawContentString ?? materialSpecification?.materialSpecifications![0].name ?? "";
    }

    getRequirementSpecificationMoneyShortName(requirementSpecificationMoney: ApplicationModelsApiModelsApiRequirementSpecification){
        if (requirementSpecificationMoney.classType !== ApplicationModelsApiModelsApiRequirementSpecificationTypes.Money){
            return "";
        }
        const moneySpecification = requirementSpecificationMoney as ApplicationModelsApiModelsApiRequirementSpecificationMoney;
        if(!moneySpecification.quantitySpecification?.value){
            return "";
        }
        return formatMoney(moneySpecification.quantitySpecification.value, this.localeDataProvider.locale, "euro");
    }
}
