class Transcriptor {
    private strandMap : {[key:string]:string} = {
        G : 'C',
        C : 'G',
        T : 'A',
        A : 'U'
    };

    toRna( strand:string ) :string{
        return strand
            .split("")
            .map(item => {
                const mapElement = this.strandMap[item];

                if (mapElement != null) {
                    mapElement;
                } else {
                    throw new Error("Invalid input DNA.");
                }
                return mapElement;
            })
            .join("");
    }
}

export default Transcriptor