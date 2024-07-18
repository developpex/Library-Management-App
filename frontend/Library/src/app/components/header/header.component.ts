import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  constructor(
    public authService: AuthService,
    private router: Router,
    private notificationService: NotificationService
  ) {}

  logout() {
    this.authService.logout().subscribe({
      next: () => {
        this.router.navigateByUrl('login');
        this.notificationService.showSuccess('logged out succesfull');
      },
    });
  }
}
