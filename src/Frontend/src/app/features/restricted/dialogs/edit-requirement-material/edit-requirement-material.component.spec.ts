import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRequirementMaterialComponent } from './edit-requirement-material.component';

describe('EditRequirementMaterialComponent', () => {
  let component: EditRequirementMaterialComponent;
  let fixture: ComponentFixture<EditRequirementMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditRequirementMaterialComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditRequirementMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
