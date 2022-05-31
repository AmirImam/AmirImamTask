import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemBalancesReportComponent } from './item-balances-report.component';

describe('ItemBalancesReportComponent', () => {
  let component: ItemBalancesReportComponent;
  let fixture: ComponentFixture<ItemBalancesReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemBalancesReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemBalancesReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
