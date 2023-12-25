ew Vue({
    el: '#registerApp',
    data: {
        imageUrl: ''
    },
    methods: {
        updateImage() {
            if (!this.imageUrl) {
                this.imageUrl = 'https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/Person_icon_BLACK-01.svg/1924px-Person_icon_BLACK-01.svg.png';
            }
        }
    }
});