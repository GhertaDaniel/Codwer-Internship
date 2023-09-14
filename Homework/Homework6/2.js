const day = prompt('Introdu ziua saptaminii');

function getDayOfTheWeek() {
    switch(day) {
        case 'luni':
            alert('Zi lucratoare');
            break;
        case 'marti':
            alert('Zi lucratoare');
            break;
        case 'miercuri':
            alert('Zi lucratoare');
            break;
        case 'joi':
            alert('Zi lucratoare');
            break;
        case 'vineri':
            alert('Zi lucratoare');
            break;
        case 'sambata':
            alert('Zi de odihna');
            break;
        case 'duminica':
            alert('Zi de odihna');
            break;
        default:
            alert('Nu este definit, incercati alta valoare');
            break;
    }
}

getDayOfTheWeek()