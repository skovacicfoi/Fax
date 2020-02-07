
var firstHour = 8;
var numOfHours = 13;


function GenerateEvents(eventsJson) {

    var parseModel = eventsJson.replace(/&quot;/g, '"');

    var parsed = JSON.parse(parseModel);

    console.log(parsed);

    parsed.forEach(function (item) {
        var eventHours = ExtractHours(item.Start);
        var eventMinutes = ExtractMinutes(item.Start);


        var eventMinutesEnd = ExtractMinutes(item.End);
        var eventHourEnd = ExtractHours(item.End);



        var position = CalculatePosition(eventHours, eventMinutes);

        var height = CalculateHeight(eventHours, eventMinutes, eventHourEnd, eventMinutesEnd)

        InsertEvent(position, height, item.DayOfWeek);
        
    });
}

function InsertEvent(position, height, dayOfWeek) {
    var dayOfWeekId;

    switch (dayOfWeek) {
        case 1: {
            dayOfWeekId = "Monday";
            break;
        }
        case 2: {
            dayOfWeekId = "Tuesday";
            break;
        }
        case 3: {
            dayOfWeekId = "Wednesday";
            break;
        }
        case 4: {
            dayOfWeekId = "Thursday";
            break;
        }
        case 5: {
            dayOfWeekId = "Friday";
            break;
        }
         
        default:
    }

    var newEvent = document.createElement("div"); 

    newEvent.setAttribute("class", "Predavanja");
    newEvent.style.height = height + "%";
    newEvent.style.top = position + "%";
    newEvent.textContent ="TIP " + " TRAJANJE"

    var k = document.getElementById(dayOfWeekId);
    k.appendChild(newEvent);
}


function CalculateHeight(startHour, startMinute, endHour, endMinute) {
    var numMins = (numOfHours) * 60;
    var minuteHeight = 100 / numMins;

    var height = ((endHour * 60 + +endMinute) - (startHour * 60 + +startMinute)) * minuteHeight +(60*minuteHeight);

    return height;
}

function CalculatePosition(startHour, startMinute) {
    var numMins = (numOfHours) * 60;
    var minuteHeight = 100 / numMins;

    var itemPosition = ((startHour - firstHour) * 60 * minuteHeight) + (startMinute * minuteHeight); 
    return itemPosition;
}

function ExtractHours(time) {
    var eventTime = new Date(time);
    eventTime = eventTime.toLocaleTimeString('it-IT')

    var splitTime = eventTime.split(':');

    
    return splitTime[0];
}

function ExtractMinutes(time) {
    var eventTime = new Date(time);
    eventTime = eventTime.toLocaleTimeString('it-IT')

    var splitTime = eventTime.split(':');

    return splitTime[1];
}


//Insert hours column for scheduler

function InsertHoursColumn() {
    var hoursColumn = document.getElementById("scheduler-hours");
    console.log(hoursColumn);

    var numMins = numOfHours * 60;
    var minuteHeight = 100 / numMins;

    for (var i = 0; i < numOfHours; i++) {

        var newHour = document.createElement("div"); 
        newHour.setAttribute("class", "day-time");
        newHour.textContent = +firstHour + i;
        hoursColumn.appendChild(newHour);
        newHour.style.top = ((+i * 60) * minuteHeight) + "%";
        newHour.style.height = (100 / numOfHours) + "%";
    }

}


