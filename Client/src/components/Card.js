import React from 'react';

const Card = ({ isEpisodeNotCharacter }) => {
    const shadow = isEpisodeNotCharacter ? 'shadow-black shadow-xl' : 'shadow-black shadow-xl';

    if (isEpisodeNotCharacter) {
        return (
            <div className={` rounded-3xl ${shadow}`} onClick={() => { return; }}>
                <div className="p-4">
                    <h1 className="text-lime-100 font-bold text-base">Episode Name</h1>
                    <p className="text-lime-100 text-xs">Episode Code</p>
                    <p className="text-lime-100 text-xs">Air Date</p>
                </div>
            </div>
        );
    }
    else {
        return (
            <div className={`rounded-3xl ${shadow}`} onClick={() => { console.log('clicked'); }}>
                <div className="p-4">
                    <h1 className="text-lime-100 font-bold text-base">Character Name</h1>
                    <p className="text-lime-100 text-xs">Status</p>
                    <p className="text-lime-100">Species</p>
                    <p className="text-lime-100">
                        <span className="text-lime-100">Origin: </span>
                        <span className="text-lime-100">Origin Name</span>
                    </p>
                    <p className="text-lime-100">
                        <span className="text-lime-100">Location: </span>
                        <span className="text-lime-100">Location Name</span>
                    </p>
                </div>
            </div>
        );
    }

};

export default Card;
