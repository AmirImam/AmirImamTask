import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemStoresComponent } from './item-stores.component';

describe('ItemStoresComponent', () => {
  let component: ItemStoresComponent;
  let fixture: ComponentFixture<ItemStoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemStoresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemStoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
