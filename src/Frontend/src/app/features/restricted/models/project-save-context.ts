import {ProjectInput} from "./project-input";
import {ApplicationModelsApiModelsApiProjectBody} from "../../../server/model/applicationModelsApiModelsApiProjectBody";
import {Language} from "../../../core/types/general-types";

export class ProjectSaveContext{
    isSaving : boolean = false;
    hasChanges: boolean = false;
    lastSave: Date | null = null;
    madeChangesWhileSaving: boolean = false;
    lastSavedProjectRequest: ApplicationModelsApiModelsApiProjectBody | null = null;
    onChange(projectInput: ProjectInput, mainLanguage: Language){
        if(this.hasChanges){
            return;
        }
        
        projectInput.buildRequest(mainLanguage).then((x) => {
            if(JSON.stringify(this.lastSavedProjectRequest) === JSON.stringify(x)){
                return;
            }
            if(this.isSaving){
                this.madeChangesWhileSaving = true;
            }
            this.hasChanges = true; 
        });
    }
}