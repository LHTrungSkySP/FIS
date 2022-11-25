export function togglePasswordTextBox(input,btn){
    const ipnElements = document.querySelectorAll(input)
    // nút ấn vào thì thực hiện 
    const btnElements = document.querySelectorAll(btn)

    for(let i=0;i<ipnElements.length;i++){
        btnElements[i].addEventListener('click', function() {
            // step 3
            const currentType = ipnElements[i].getAttribute('type')
            // step 4
            ipnElements[i].setAttribute(
              'type',
              currentType === 'password' ? 'text' : 'password'
            )
        })
    }
} 