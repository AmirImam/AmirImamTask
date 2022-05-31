import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoresIndexComponent } from './stores-index.component';

describe('StoresIndexComponent', () => {
  let component: StoresIndexComponent;
  let fixture: ComponentFixture<StoresIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StoresIndexComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StoresIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
