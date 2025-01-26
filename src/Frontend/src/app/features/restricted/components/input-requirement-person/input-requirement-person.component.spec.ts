import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputRequirementPersonComponent } from './input-requirement-person.component';

describe('InputRequirementPersonComponent', () => {
  let component: InputRequirementPersonComponent;
  let fixture: ComponentFixture<InputRequirementPersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputRequirementPersonComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputRequirementPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
