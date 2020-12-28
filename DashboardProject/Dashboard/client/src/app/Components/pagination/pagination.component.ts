import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {

  isPageNumberValid : boolean = true;

  @Input() currentPage: number;
  @Input() count: number;
  @Input() pageSize: number;
  @Input() pagesToShow: number;

  @Output() goPrev = new EventEmitter<boolean>();
  @Output() goNext = new EventEmitter<boolean>();
  @Output() goPage = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {   
  }

  onPrev() : void {   
    this.goPrev.emit(true);
  }

  onNext() : void {
    this.goNext.emit(true);
  }

  onPage(n: number) : void {
    this.goPage.emit(n);
  }

  // totalPages() : number {
  //   return Math.ceil(this.count/this.pageSize) || 0
  //   // return this.pagesToShow;
  // }

  isLast() : boolean {
    return this.pageSize * this.currentPage >= this.count
  }

  goToPage(event: any) : void {
    let value = Number(event.target[0].value);    
    
    if (value > 0 && value <= this.pagesToShow){
      this.isPageNumberValid = true;
      this.goPage.emit(value);
    } else {
      this.isPageNumberValid = false;
    }
  }
}