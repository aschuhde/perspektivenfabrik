import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IconRainbowComponent } from './icon-rainbow.component';

describe('IconRainbowComponent', () => {
  let component: IconRainbowComponent;
  let fixture: ComponentFixture<IconRainbowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IconRainbowComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IconRainbowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
