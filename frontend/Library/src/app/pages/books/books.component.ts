import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { BooksService } from '../../services/books.service';
import { Book } from '../../models/book.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { BookDialogComponent } from '../../book-dialog/book-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss',
})
export class BooksComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['title', 'authors'];
  dataSource = new MatTableDataSource<Book>();
  clickedRows = new Set<Book>();

  constructor(private booksService: BooksService, public dialog: MatDialog) {}

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.booksService.getBooks().subscribe({
      next: (response) => {
        this.dataSource.data = response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      },
      complete: () => {
        console.log('Data fetch complete');
      },
    });
  }

  openDialog(book: Book): void {
    this.dialog.open(BookDialogComponent, {
      data: book,
    });
  }
}
