import { GalleryImage } from './galleryImage.model';

describe('GalleryImage', () => {
    let model: GalleryImage;

    beforeEach(() => {
        model = new GalleryImage();
    });

    it('should be create successfully', () => {
        // Arrange, Act & Assert
        expect(model).toBeTruthy();
    });
    it('should property $key be assign correctly', () => {
        // Arrange
        const testKey = 'testKey';
        // Act
        model.$key = testKey;
        // Assert
        expect(model.$key).toEqual(testKey);
    });
    it('should property name be assign correctly', () => {
        // Arrange
        const testName = 'testName';
        // Act
        model.name = testName;
        // Assert
        expect(model.name).toEqual(testName);
    });
    it('should property url be assign correctly', () => {
        // Arrange
        const testUrl = 'testUrl/url/dir';
        // Act
        model.url = testUrl;
        // Assert
        expect(model.url).toEqual(testUrl);
    });
    it('should property uploadedOn be assign correctly', () => {
        // Arrange
        const testUploadedOn = '10/12/2018';
        // Act
        model.uploadedOn = testUploadedOn;
        // Assert
        expect(model.uploadedOn).toEqual(testUploadedOn);
    });
    it('should property uploadedBy be assign correctly', () => {
        // Arrange
        const testUploadedBy = 'testName';
        // Act
        model.uploadedBy = testUploadedBy;
        // Assert
        expect(model.uploadedBy).toEqual(testUploadedBy);
    });
});
