import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputRequirementMaterialComponent } from './input-requirement-material.component';

describe('InputRequirementMaterialComponent', () => {
  let component: InputRequirementMaterialComponent;
  let fixture: ComponentFixture<InputRequirementMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputRequirementMaterialComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputRequirementMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
