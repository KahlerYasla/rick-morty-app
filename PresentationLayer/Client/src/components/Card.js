const Card = ({ isEpisodeNotCharacter, isDeletable }) => {
    const openDialog = () => {
        alert('Character Info');
    };

    if (isEpisodeNotCharacter) {
        return (
            <div className={`flex justify-center items-center rounded-3xl shadow-2xl shadow-black`} onClick={openDialog}>
                <div className="p-4 text-center">
                    <h1 className="text-lime-100 font-bold text-base">Episode Name</h1>
                    <p className="text-lime-100 text-xs">Episode Code</p>
                    <p className="text-lime-100 text-xs">Air Date</p>
                </div>
            </div>
        );
    } else {
        return (
            <div className={`flex justify-center rounded-3xl shadow-2xl shadow-black`} onClick={openDialog}>
                <div className="p-4 grid  gap-1 text-center">
                    <img className="rounded-full w-24 h-24 m-auto" src="https://rickandmortyapi.com/api/character/avatar/1.jpeg" alt="Character" />
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
                    {/* add favorite button here */}
                    <button className="bg-lime-600 shadow-xl text-white rounded-3xl px-3 mt-2 h-6 text-xs" type="submit">Add to Favorites</button>
                    {isDeletable && (
                        <button className="bg-red-600 shadow-xl text-white rounded-3xl px-3 mt-2 h-6 text-xs" type="submit">Delete</button>
                    )}
                </div>
            </div>
        );
    }
};

export default Card;
