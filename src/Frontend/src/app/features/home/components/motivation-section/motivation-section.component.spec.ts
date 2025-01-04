import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MotivationSectionComponent } from './motivation-section.component';

describe('MotivationSectionComponent', () => {
  let component: MotivationSectionComponent;
  let fixture: ComponentFixture<MotivationSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MotivationSectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MotivationSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
