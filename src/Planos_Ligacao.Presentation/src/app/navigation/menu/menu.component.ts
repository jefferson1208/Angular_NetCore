import { Component } from "@angular/core";

@Component({
    selector: 'menu',
    templateUrl: './menu.component.html',

})
export class MenuComponent {
    navbarOpen = false;

    toggleNavbar() {
        this.navbarOpen = !this.navbarOpen;
    }
}