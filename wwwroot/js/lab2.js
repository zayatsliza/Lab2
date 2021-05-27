const uri = 'api/Universities';
let universities = [];

function getUniversities() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayUniversities(data))
        .catch(error => console.error('Unable to get universities.', error));
}

function addUniversity() {
    const addNameTextbox = document.getElementById('add-name');

    const university = {
        name: addNameTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(university)
    })
        .then(response => response.json())
        .then(() => {
            getUniversities();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add university.', error));
}

function deleteUniversity(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getUniversities())
        .catch(error => console.error('Unable to delete university.', error));
}

function displayEditForm(id) {
    const university = universities.find(university => university.id === id);

    document.getElementById('edit-id').value = university.id;
    document.getElementById('edit-name').value = university.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateUniversity() {
    const universityId = document.getElementById('edit-id').value;
    const university = {
        id: parseInt(universityId, 10),
        name: document.getElementById('edit-name').value.trim()

    };

    fetch(`${uri}/${universityId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(university)
    })
        .then(() => getUniversities())
        .catch(error => console.error('Unable to update university.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayUniversities(data) {
    const tBody = document.getElementById('universities');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(university => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${university.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteUniversity(${university.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(university.name);
        td1.appendChild(textNode);


        let td3 = tr.insertCell(1);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(2);
        td4.appendChild(deleteButton);
    });

    universities = data;
}

