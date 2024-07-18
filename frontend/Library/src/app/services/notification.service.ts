import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private toaster: ToastrService) {}

  public showError(message: string, title?: string): void {
    this.toaster.error(message, title, {
      positionClass: 'toast-bottom-center',
    });
  }

  public showInfo(message: string, title?: string): void {
    this.toaster.info(message, title, {
      positionClass: 'toast-bottom-center',
    });
  }

  public showSuccess(message: string, title?: string): void {
    this.toaster.success(message, title, {
      positionClass: 'toast-bottom-center',
    });
  }
}
