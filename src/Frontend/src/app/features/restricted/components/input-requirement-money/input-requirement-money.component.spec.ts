import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputRequirementMoneyComponent } from './input-requirement-money.component';

describe('InputRequirementMoneyComponent', () => {
  let component: InputRequirementMoneyComponent;
  let fixture: ComponentFixture<InputRequirementMoneyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputRequirementMoneyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputRequirementMoneyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
