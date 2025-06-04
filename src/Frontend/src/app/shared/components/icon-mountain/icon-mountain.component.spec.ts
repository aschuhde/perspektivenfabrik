import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IconMountainComponent } from './icon-mountain.component';

describe('IconMountainComponent', () => {
  let component: IconMountainComponent;
  let fixture: ComponentFixture<IconMountainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IconMountainComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IconMountainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
