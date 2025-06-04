import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IconWallComponent } from './icon-wall.component';

describe('IconWallComponent', () => {
  let component: IconWallComponent;
  let fixture: ComponentFixture<IconWallComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IconWallComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IconWallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
