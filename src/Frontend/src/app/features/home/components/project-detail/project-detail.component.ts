import { Component, model } from '@angular/core';
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

@Component({
  selector: 'app-project-detail',
  imports: [ImageGalleryComponent],
  templateUrl: './project-detail.component.html',
  styleUrl: './project-detail.component.scss'
})
export class ProjectDetailComponent {    
    apiProject = model.required<ApplicationModelsApiModelsApiProject | null>();

    get project(){
      return this.apiProject();
    }

    get shortDescription(){
      return this.project?.descriptionSpecifications?.find(x => x.type?.name === "shortDescription")?.content?.rawContentString;
    }

    get longDescription(){
      return this.project?.descriptionSpecifications?.find(x => x.type?.name === "longDescription")?.content?.rawContentString;
    }

    get projectTitle(){
      return this.project?.projectTitle?.rawContentString;
    }

    get projectImages(){      
      return this.project?.graphicsSpecifications?.filter(x => x.type !== 'Logo').map(x => ObjectCreator.Create<GalleryImage>({
        imageName: "",
        src: "data:image/png;base64, " + (x.content?.content ?? ""),
        alt: ""
      })) ?? [];
    }  
    get locationSpecifications(){
      return this.project?.locationSpecifications ?? [];
    }
    get timeSpecifications(){
      return this.project?.timeSpecifications ?? [];
    }
    get tags(){
      return this.project?.projectTags ?? [];
    }
    get requirementSpecificationPersons(){
      return this.project?.requirementSpecifications?.filter(x => x.classType === ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person) ?? [];
    }
    get requirementSpecificationOthers(){
      return this.project?.requirementSpecifications?.filter(x => x.classType !== ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person) ?? [];
    }

    get contactPersonalName(){
      return (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PersonalName) as ApplicationModelsApiModelsApiContactSpecificationPersonalName)?.personalName;
    }
    get contactOrganisationName(){
      return (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.OrganisationName) as ApplicationModelsApiModelsApiContactSpecificationOrganisationName)?.organisationName;
    }
    get contactPhone(){
      return (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.PhoneNumber) as ApplicationModelsApiModelsApiContactSpecificationPhoneNumber)?.phoneNumber?.phoneNumberText;
    }
    get contactMailAddress(){
      return (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.MailAddress) as ApplicationModelsApiModelsApiContactSpecificationMailAddress)?.mailAddress?.mail;
    }
    get contactWebsite(){
      return (this.project?.contactSpecifications?.find(x=> x.classType === ApplicationModelsApiModelsApiContactSpecificationTypes.Website) as ApplicationModelsApiModelsApiContactSpecificationWebsite)?.website?.rawUrl;
    }
    
    getLocationSpecificationShortName(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification){
      return "";
    }

    getTimeSpecificationShortName(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification){
      return "";
    }
    getTagShortName(tag: ApplicationModelsApiModelsApiProjectTag){
      return "";
    }

    getRequirementSpecificationPersonShortName(requirementSpecificationPerson: ApplicationModelsApiModelsApiRequirementSpecificationPerson){
      return "";
    }

    getRequirementSpecificationOtherShortName(requirementSpecificationOther: ApplicationModelsApiModelsApiRequirementSpecification){
      return "";
    }

}
