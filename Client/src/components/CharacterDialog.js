import React from 'react';

const CharacterDialog = ({ characterName, onClose }) => {
    return (
        <div className="dialog">
            <h2>{characterName}</h2>
            <p>This is the dialog box content.</p>
            <button onClick={onClose}>Close</button>
        </div>
    );
};

export default CharacterDialog;
