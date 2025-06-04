import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IconThreeHatsTiltedComponent } from './icon-three-hats-tilted.component';

describe('IconThreeHatsTiltedComponent', () => {
  let component: IconThreeHatsTiltedComponent;
  let fixture: ComponentFixture<IconThreeHatsTiltedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IconThreeHatsTiltedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IconThreeHatsTiltedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
