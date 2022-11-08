// Author: Lê hoàng trung 
$(document).ready(function () {
    intitEvent();
    // kiểm tra target
    // $(document).click(function(evt){
    //     debugger
    // })
})

function intitEvent() {
    intitNavbar();
    intitTour();
}

// function at navbar 
function intitNavbar() {
    responsiveNavbar();
}
function responsiveNavbar() {
    let mobileMenu = document.getElementById('mobileMenu');
    let navbar = document.getElementById('navbar')
    // click navbar 
    
    mobileMenu.addEventListener('click',toggleNavbar(navbar,navbar.clientHeight));

    // click link of navbar 
    let menuItems = document.querySelectorAll("#main>.header>.navbar .container-navbar>a");


    for(var i=1;i<menuItems.length;i++){
        var menuItem = menuItems[i];
        var isParentMenu = menuItem.nextElementSibling && menuItem.nextElementSibling.classList.contains('sub-navbar');
        if(!isParentMenu){
            menuItem.addEventListener('click',toggleNavbar(navbar,navbar.clientHeight));
        }
    }

}
function toggleNavbar(navbar,h){
    return function(){
        console.log(h)
        var isOpened = navbar.clientHeight === h;
        if (isOpened) {
            navbar.style.height = 'auto';
            console.log('mở');
        }
        else {

            navbar.style.height = null;

            console.log('đóng');
        }

    }

}
// function at Tour 
function intitTour(){
    const buyBtns = document.querySelectorAll('.js-buy-ticket');

    // mở modal ticket 
    for(let buyBtn of buyBtns){
        buyBtn.addEventListener('click',showModal)
    }

    // đóng modal ticket 
    const closeBuyBtns = document.querySelectorAll('.js-close-buy-ticket');
    const tiscketModal = document.querySelector('#ticketModal');
    
    // closeBuyBtns.push(tiscketModal)
    for(let closeBuyBtn of closeBuyBtns){
        closeBuyBtn.addEventListener('click',closeModal);
    }

    // click ra ngoài đóng modal ticket
    const modalBox = document.querySelector('.js-modal-box')
    modalBox.addEventListener('click',function(event){
        event.stopPropagation();
    })


}

function showModal() {
    console.log("mở");
    $('#ticketModal').show();
}

function closeModal() {
    console.log("đóng");
    $('#ticketModal').hide();
}
