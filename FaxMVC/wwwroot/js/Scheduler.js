
var firstHour = 8;
var numOfHours = 13;

const columns = document.getElementsByClassName("EventsContainer");
const select = document.getElementById("schedulePicker");

function ClearColumns() {
    Array.from(columns).forEach((item) => {
        while (item.firstChild) {
            item.removeChild(item.firstChild);
        }
    });
}

function GetEvents() {
    console.log("s");
    var id = select.options[select.selectedIndex].value;
    console.log(id);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:44315/api/EventsApi/" + id,
        success: function (data) {
            console.log(data);
            ClearColumns();
            GenerateEvents(data);
        },
        error: function (error) {

        }
    });
}



function GenerateEvents(eventsJson) {

    eventsJson.forEach(function (item) {
        var eventHours = ExtractHours(item.Start);
        var eventMinutes = ExtractMinutes(item.Start);


        var eventMinutesEnd = ExtractMinutes(item.End);
        var eventHourEnd = ExtractHours(item.End);



        var position = CalculatePosition(eventHours, eventMinutes);

        var height = CalculateHeight(eventHours, eventMinutes, eventHourEnd, eventMinutesEnd)

        InsertEvent(position, height, item.DayOfWeek);

    });
}

//function GenerateEvents(eventsJson) {

//    var parseModel = eventsJson.replace(/&quot;/g, '"');

//    var parsed = JSON.parse(parseModel);


//    parsed.forEach(function (item) {
//        var eventHours = ExtractHours(item.Start);
//        var eventMinutes = ExtractMinutes(item.Start);


//        var eventMinutesEnd = ExtractMinutes(item.End);
//        var eventHourEnd = ExtractHours(item.End);



//        var position = CalculatePosition(eventHours, eventMinutes);

//        var height = CalculateHeight(eventHours, eventMinutes, eventHourEnd, eventMinutesEnd)

//        InsertEvent(position, height, item.DayOfWeek);

//    });
//}

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
    newEvent.textContent = "TIP " + " TRAJANJE"

    var k = document.getElementById(dayOfWeekId);
    k.appendChild(newEvent);
}


function CalculateHeight(startHour, startMinute, endHour, endMinute) {
    var numMins = (numOfHours) * 60;
    var minuteHeight = 100 / numMins;

    var height = ((endHour * 60 + +endMinute) - (startHour * 60 + +startMinute)) * minuteHeight + (60 * minuteHeight);

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


    var numMins = (numOfHours) * 60;
    var minuteHeight = 100 / numMins;

    for (var i = 0; i < numOfHours; i++) {

        var newHour = document.createElement("div");
        newHour.setAttribute("class", "day-time");

        if (+firstHour + i < 10) {
            newHour.textContent = +"0" + firstHour + i + ":00h";

        }
        else {
            newHour.textContent = +firstHour + i + ":00h";
        }

        hoursColumn.appendChild(newHour);
        newHour.style.top = ((+i * 60) * minuteHeight) + "%";
        newHour.style.height = (minuteHeight * 60) + "%";
    }

}


