import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRequirementPersonComponent } from './edit-requirement-person.component';

describe('EditRequirementPersonComponent', () => {
  let component: EditRequirementPersonComponent;
  let fixture: ComponentFixture<EditRequirementPersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditRequirementPersonComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditRequirementPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
