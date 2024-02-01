import React from 'react';

const Card = ({ isEpisodeNotCharacter }) => {
    const shadow = isEpisodeNotCharacter ? 'shadow-yellow-500 shadow-lg' : 'shadow-green-500 shadow-lg';

    if (isEpisodeNotCharacter) {
        return (
            <div className={`bg-lime-100 rounded-md ${shadow}`}>
                <div className="p-4">
                    <h1 className="text-lime-900 text-xl font-bold">Episode Name</h1>
                    <p className="text-lime-900">Episode Code</p>
                    <p className="text-lime-900">Air Date</p>
                </div>
            </div>
        );
    }
    else {
        return (
            <div className={`bg-lime-100 rounded-md ${shadow}`}>
                <div className="p-4">
                    <h1 className="text-lime-900 text-xl font-bold">Character Name</h1>
                    <p className="text-lime-900">Status</p>
                    <p className="text-lime-900">Species</p>
                    <p className="text-lime-900">
                        <span className="text-lime-900">Origin: </span>
                        <span className="text-lime-900">Origin Name</span>
                    </p>
                    <p className="text-lime-900">
                        <span className="text-lime-900">Location: </span>
                        <span className="text-lime-900">Location Name</span>
                    </p>
                </div>
            </div>
        );
    }

};

export default Card;
