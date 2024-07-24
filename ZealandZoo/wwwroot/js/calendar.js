document.addEventListener('DOMContentLoaded', function () {
    let currentView = 'monthly'; // Default view
    let currentDate = new Date();
    const today = new Date();

    // Initial rendering
    renderCalendar(currentDate, currentView);

    document.getElementById('prev').addEventListener('click', () => {
        if (currentView === 'monthly') {
            currentDate.setMonth(currentDate.getMonth() - 1);
        } else if (currentView === 'yearly') {
            currentDate.setFullYear(currentDate.getFullYear() - 1);
        }
        renderCalendar(currentDate, currentView);
    });

    document.getElementById('next').addEventListener('click', () => {
        if (currentView === 'monthly') {
            currentDate.setMonth(currentDate.getMonth() + 1);
        } else if (currentView === 'yearly') {
            currentDate.setFullYear(currentDate.getFullYear() + 1);
        }
        renderCalendar(currentDate, currentView);
    });

    document.getElementById('toggle-view').addEventListener('click', () => {
        currentView = currentView === 'monthly' ? 'yearly' : 'monthly';
        renderCalendar(currentDate, currentView);
    });

    document.getElementById('current-month').addEventListener('click', () => {
        currentDate = new Date(today); // Reset to current date
        currentView = 'monthly'; // Switch to monthly view if not already
        renderCalendar(currentDate, currentView);
    });

    async function fetchEvents(date) {
        const response = await fetch(`/Calendar?handler=EventsByDate&date=${date.toISOString()}`);
        const events = await response.json();
        return events;
    }

    async function renderCalendar(date, view) {
        const container = document.getElementById('calendar-container');
        container.innerHTML = ''; // Clear previous calendar

        if (view === 'monthly') {
            await renderMonthlyCalendar(date, container);
        } else if (view === 'yearly') {
            renderYearlyCalendar(date, container);
        }
    }

    async function renderMonthlyCalendar(date, container) {
        const month = date.getMonth();
        const year = date.getFullYear();
        const firstDay = new Date(year, month, 1);
        const lastDay = new Date(year, month + 1, 0);

        const monthNames = ["January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"];

        const table = document.createElement('table');
        const headerRow = table.insertRow();
        const headerCell = document.createElement('th');
        headerCell.colSpan = 7;
        headerCell.innerText = `${monthNames[month]} ${year}`;
        headerRow.appendChild(headerCell);

        const daysRow = table.insertRow();
        ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"].forEach(day => {
            const cell = document.createElement('td');
            cell.innerText = day;
            daysRow.appendChild(cell);
        });

        let currentRow = table.insertRow();
        for (let i = 0; i < firstDay.getDay(); i++) {
            currentRow.insertCell();
        }

        for (let day = 1; day <= lastDay.getDate(); day++) {
            if (currentRow.cells.length === 7) {
                currentRow = table.insertRow();
            }
            const cell = currentRow.insertCell();
            cell.innerText = day;

            // Highlight the current day
            if (year === today.getFullYear() && month === today.getMonth() && day === today.getDate()) {
                cell.classList.add('current-day');
            }

            // Fetch and display events
            const cellDate = new Date(year, month, day);
            const events = await fetchEvents(cellDate);
            if (events.length > 0) {
                const eventList = document.createElement('ul');
                events.forEach(event => {
                    const eventItem = document.createElement('li');
                    eventItem.innerText = event.title;
                    eventList.appendChild(eventItem);
                });
                cell.appendChild(eventList);
            }

            // Add event listeners to open event details or edit
            cell.addEventListener('click', () => {
                // For demonstration, alert event details
                alert(`Date: ${cellDate.toDateString()}\nEvents:\n${events.map(e => e.title).join('\n')}`);
            });
        }

        container.appendChild(table);
    }

    function renderYearlyCalendar(date, container) {
        const year = date.getFullYear();
        const monthNames = ["January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"];

        const yearHeader = document.createElement('h3');
        yearHeader.innerText = year;
        container.appendChild(yearHeader);

        const table = document.createElement('table');
        const headerRow = table.insertRow();
        const headerCell = document.createElement('th');
        headerCell.colSpan = 4;
        headerCell.innerText = year;
        headerRow.appendChild(headerCell);

        let currentRow = table.insertRow();
        monthNames.forEach((month, index) => {
            if (index % 4 === 0 && index !== 0) {
                currentRow = table.insertRow();
            }
            const cell = currentRow.insertCell();
            cell.innerText = month;

            // Highlight the current month
            if (year === today.getFullYear() && index === today.getMonth()) {
                cell.classList.add('current-month');
            }

            cell.addEventListener('click', () => {
                currentDate.setMonth(index);
                currentView = 'monthly';
                renderCalendar(currentDate, currentView);
            });
        });

        container.appendChild(table);
    }
});
